﻿using Microsoft.AspNetCore.Mvc;
using OnlineBingoAPI.CustomException;
using System;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Controllers
{
    public class DefaultController: ControllerBase
    {
        protected async Task<IActionResult> ExecuteCall(Func<Task<IActionResult>> action)
        {
            try
            {
                return await action();
            }
            catch (BusinesRuleException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}