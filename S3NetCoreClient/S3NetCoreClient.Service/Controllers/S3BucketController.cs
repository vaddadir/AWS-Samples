using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace S3NetCoreClient.Service.Controllers
{
    [Route("api/[controller]")]
    public class S3BucketController : Controller
    {
        private IAmazonS3 _s3Client;

        public S3BucketController(IAmazonS3 client)
        {
            this._s3Client = client;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<S3Bucket> GetAsync()
        {
            ListBucketsResponse listBucketsResponse = await _s3Client.ListBucketsAsync();
            return listBucketsResponse.Buckets;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}