using refactor_this.Models;
using System;
using System.Web.Http;

namespace refactor_this.Controllers
{
    public class TransactionController : ApiController
    {
        
        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult GetTransactions(Guid id)
        {
            try
            {
                Transaction transaction = new Transaction();
                return Ok(transaction.Get(id));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transaction transaction)
        {
            Account account = new Account();
            bool rc_update=false;
            bool rc_insert=false;
            try
            {
                //If Amount=0, jump to the insert step
                if (transaction.Amount != 0)
                {
                    //update the amount of Accounts table
                    rc_update = account.UpdateAmount(id, transaction.Amount);
                    if (!rc_update)
                        //return update error
                        return BadRequest("Could not update account amount");
                }
                rc_insert = transaction.Insert(id);
                if (!rc_insert)
                {
                    //restore update
                    if(transaction.Amount !=0)
                        account.UpdateAmount(id, transaction.Amount * Convert.ToDecimal(-1));
                    //return update error
                    return BadRequest("Could not insert the transaction");
                }
                
                return Ok();
            }
            catch(Exception e)
            {
                //restore update when shot down happened after updating.
                if (rc_update && !rc_insert)
                {
                    account.UpdateAmount(id, transaction.Amount * Convert.ToDecimal(-1));
                }
                throw e;
            } 
        }
    }
}