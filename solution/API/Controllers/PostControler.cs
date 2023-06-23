using AutoMapper;
using LearningCenter.Infraestructure.Models;
using LearningCenter.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCenter.API.Input;
using LearningCenter.API.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using LearningCenter.API.Filter;

namespace LearningCenter.API.Controllers
{
    [Route("api/[controller]")]
    
    [Filter.Authorize("admin")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostInfraestructure _postInfraestructure;
        private IMapper _mapper;


        public PostController(IPostInfraestructure postInfraestructure, IMapper mapper)
        {
            _postInfraestructure = postInfraestructure;
            _mapper = mapper;
        }

        // GET: api/Post
        [HttpGet(Name = "GetPosts")]
        public async Task<IActionResult> Get()
        {
            var result = await _postInfraestructure.GetAll();
            var posts = _mapper.Map<List<Post>, List<PostResponse>>(result);
            return Ok(posts);
        }

        // GET: api/Post/5
        /*[HttpGet("{id}", Name = "GetPostById")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }*/

        // POST: api/Post
        [HttpPost(Name = "CreatePost")]
        public async Task<IActionResult> Post([FromBody] PostInput postInput)
        {
            var post = _mapper.Map<PostInput, Post>(postInput); 
            await _postInfraestructure.CreateAsync(post);

            return Ok();
        }

        // PUT: api/Post/5
        [HttpPut("{id}", Name = "UpdatePost")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}", Name = "DeletePost")]
        public void Delete(int id)
        {
        }
    }
}