using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorService.Server.Controllers;
using CalculatorService.Server.Models;
using System.Net;
using System.Web.Http;

namespace CalculatorService.Server.Tests
{
    [TestClass]
    public class TestCalculatorController
    {

        /// <summary>
        ///  ADD
        /// </summary>
        [TestMethod]
        public void Add_ShouldReturnOK()
        {
            AddRequest testRequest = new AddRequest();
            testRequest.Addends = new int[] { 3, 4, 5 };
            
            var controller = new CalculatorController();

            var result = controller.add(testRequest) as AddResponse;
            Assert.AreEqual(12, result.Sum);
        }

        [TestMethod]
        public void Add_ShouldReturnBadRequest()
        {
            try
            {
                AddRequest testRequest = new AddRequest();
                testRequest.Addends = null;

                var controller = new CalculatorController();

                var result = controller.add(testRequest) as AddResponse;
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);                
            }            
        }

       /// <summary>
       /// SUB
       /// </summary>

        [TestMethod]
        public void Sub_ShouldReturnOK()
        {
            SubRequest testRequest = new SubRequest();
            testRequest.Minuend = 2;
            testRequest.Subtrahend = 7;

            var controller = new CalculatorController();

            var result = controller.sub(testRequest) as SubResponse;
            Assert.AreEqual(-5, result.Difference);
        }

        [TestMethod]
        public void Sub_ShouldReturnBadRequest()
        {
            try
            {
                SubRequest testRequest = new SubRequest();               

                var controller = new CalculatorController();

                var result = controller.sub(testRequest) as SubResponse;
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        ///  MULT
        /// </summary>
        [TestMethod]
        public void Mult_ShouldReturnOK()
        {
            MultRequest testRequest = new MultRequest();
            testRequest.Factors = new int[] { 8, 3, 2 };

            var controller = new CalculatorController();

            var result = controller.mult(testRequest) as MultResponse;
            Assert.AreEqual(48, result.Product);
        }

        [TestMethod]
        public void Mult_ShouldReturnBadRequest() 
        {
            try
            {
                MultRequest testRequest = new MultRequest();
                testRequest.Factors = null;

                var controller = new CalculatorController();

                var result = controller.mult(testRequest) as MultResponse;
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// DIV
        /// </summary>

        [TestMethod]
        public void Div_ShouldReturnOK()
        {
            DivRequest testRequest = new DivRequest();
            testRequest.Dividend = 11;
            testRequest.Divisor = 2;

            var controller = new CalculatorController();

            var result = controller.div(testRequest) as DivResponse;
            DivResponse compare = new DivResponse { Quotient = 5, Remainder = 1 };
            Assert.AreEqual(5, result.Quotient);
            Assert.AreEqual(1, result.Remainder);

        }

        [TestMethod]
        public void Div_ShouldReturnBadRequest()
        {
            try
            {
                DivRequest testRequest = null;

                var controller = new CalculatorController();

                var result = controller.div(testRequest) as DivResponse;
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// SQRT
        /// </summary>

        [TestMethod]
        public void Sqrt_ShouldReturnOK()
        {
            SqrtRequest testRequest = new SqrtRequest();
            testRequest.Number = 16;
            

            var controller = new CalculatorController();

            var result = controller.sqrt(testRequest) as SqrtResponse;
           
            Assert.AreEqual(4, result.Square);           

        }

        [TestMethod]
        public void Sqrt_ShouldReturnBadRequest()
        {
            try
            {
                SqrtRequest testRequest = new SqrtRequest();

                var controller = new CalculatorController();

                var result = controller.sqrt(testRequest) as SqrtResponse;
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest);
            }
        }
    }
}
