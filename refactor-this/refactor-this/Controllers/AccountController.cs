using refactor_this.Models;
using System;
using System.Web.Http;

namespace refactor_this.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
            try
            {
                Account account = new Account();
                //show the result. If there is no data, show blank.
                return Ok(account.Get(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult Get()
        {
            try
            {
                Account account = new Account();
                //show the result. If there is no data, show blank.
                return Ok(account.Get());
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            try
            {
                if(!account.Insert())
                    //return insert error
                    return BadRequest("Could not insert the new account!");
                return Ok();
            }
            catch(Exception e)
            {
                throw e;
            } 
        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Guid id, Account account)
        {
            try
            {
                //update the name.
                if(!account.UpdateName(id))
                    return BadRequest("Could not update the name! " 
                        + "Please make sure the id is existing.");
                return Ok();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                Account account = new Account();
                //delete the id
                if(!account.Delete(id))
                    return BadRequest("Could not delete the account! " 
                        + "Please make sure the id is existing.");
                return Ok();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}