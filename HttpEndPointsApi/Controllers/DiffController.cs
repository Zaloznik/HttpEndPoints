using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using System.Text.Json.Serialization;

namespace HttpEndPointsApi.Controllers
{
    [Route("v1/diff/{id}")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        [HttpPost("left")]
        public IActionResult Left(Guid id, [FromBody] string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return BadRequest();
            }

            byte[] byteArray = Convert.FromBase64String(data);

            if(Globals.ClientData != null && Globals.ClientData.Count > 0 && Globals.ClientData.Any(x => x.id == id))
            {
                var clientObj = Globals.ClientData.Where(x => x.id == id).FirstOrDefault();
                clientObj.leftData = byteArray;
            }
            else
            {
                if(Globals.ClientData == null || Globals.ClientData.Count == 0)
                {
                    Globals.ClientData = new List<ClientObj>();
                }
                Globals.ClientData.Add(new ClientObj(id, byteArray, null));
            }
            //Globals.leftData = byteArray;

            return StatusCode(201);
        }

        [HttpPost("right")]
        public IActionResult Right(Guid id, [FromBody] string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return BadRequest();
            }

            byte[] byteArray = Convert.FromBase64String(data);

            if (Globals.ClientData != null && Globals.ClientData.Count > 0 && Globals.ClientData.Any(x => x.id == id))
            {
                var clientObj = Globals.ClientData.Where(x => x.id == id).FirstOrDefault();
                clientObj.rightData = byteArray;
            }
            else
            {
                if (Globals.ClientData == null || Globals.ClientData.Count == 0)
                {
                    Globals.ClientData = new List<ClientObj>();
                }
                Globals.ClientData.Add(new ClientObj(id, null, byteArray));
            }

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Diff(Guid id)
        {
            if (Globals.ClientData == null || Globals.ClientData.Count == 0 || !Globals.ClientData.Any(x => x.id == id))
            {
                return NotFound();
            }

            ClientObj obj = Globals.ClientData.Where(x => x.id == id).FirstOrDefault();
            if(obj != null && obj.rightData != null && obj.rightData != null)
            {
                if(obj.leftData.Length == obj.rightData.Length)
                {
                    bool same = true;
                    for (int i = 0; i < obj.leftData.Length; i++)
                    {
                        if (obj.leftData[i] != obj.rightData[i])
                        {
                            same = false;
                        }
                    }
                    if (same)
                    {
                        var jsonData = new
                        {
                            diffResultType = "Equals"
                        };

                        return Ok(jsonData);
                    }
                    else
                    {
                        DiffResult result = new DiffResult();
                        result.DiffResultType = "ContentDoNotMatch";
                        result.Diffs = new List<DiffDetail>();

                        int offset = -1;
                        int length = 0;
                        for (int i = 0; i < obj.leftData.Length; i++)
                        {
                            if (obj.leftData[i] != obj.rightData[i])
                            {
                                if (offset == -1)
                                {
                                    offset = i;
                                }
                                length++;
                            }
                            else
                            {
                                if (offset != -1)
                                {
                                    result.Diffs.Add(new DiffDetail { Offset = offset, Length = length });
                                    offset = -1;
                                    length = 0;
                                }
                            }
                        }

                        if (offset != -1)
                        {
                            result.Diffs.Add(new DiffDetail { Offset = offset, Length = length });
                        }
                        return Ok(result);
                    }
                }
                else
                {
                    var jsonData = new
                    {
                        diffResultType = "SizeDoNotMatch"
                    };
                    return Ok(jsonData);
                }
            }
            else
            {
                return NotFound();
            }
        }
    }

    public class DiffResult
    {
        public string DiffResultType { get; set; }
        public List<DiffDetail> Diffs { get; set; }
    }

    public class DiffDetail
    {
        public int Offset { get; set; }
        public int Length { get; set; }
    }
}
