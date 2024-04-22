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
        public IActionResult Left(int id, [FromBody] string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return BadRequest();
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            Globals.leftData = byteArray;

            return StatusCode(201);
        }

        [HttpPost("right")]
        public IActionResult Right(int id, [FromBody] string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return BadRequest();
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            Globals.rightData = byteArray;

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Diff(int id)
        {
            if (Globals.leftData == null || Globals.leftData.Length == 0 || Globals.rightData == null || Globals.rightData.Length == 0)
            {
                return NotFound();
            }

            if (Globals.leftData.Length == Globals.rightData.Length)
            {
                bool same = true;
                for (int i = 0; i < Globals.leftData.Length; i++)
                {
                    if (Globals.leftData[i] != Globals.rightData[i])
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
                    for (int i = 0; i < Globals.leftData.Length; i++)
                    {
                        if (Globals.leftData[i] != Globals.rightData[i])
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
