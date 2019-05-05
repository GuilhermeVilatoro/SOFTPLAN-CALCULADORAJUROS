using CalculadoraJuros.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace CalculadoraJuros.WebApi.IntegrationTests.Controllers
{
    public class ShowMeTheCodeControllerTest
    {
        private ShowMeTheCodeController _showMeTheCodeController;

        private OkObjectResult resultadoMock;

        private const string URLPROJETOGITMOCK = "https://github.com/GuilhermeVilatoro/SOFTPLAN_CALCULADORAJUROS";
        private const int STATUSCODESUCESSO = 200;

        [SetUp]
        public void SetUp()
        {
            _showMeTheCodeController = new ShowMeTheCodeController();
            resultadoMock = _showMeTheCodeController.Ok(new { success = true, data = URLPROJETOGITMOCK });
        }

        [Test]
        public void Ao_Realizar_Consumo_Show_Me_The_Code_Deve_Retornar_O_Link_Do_Projeto_No_GitHub()
        {
            var resultado = _showMeTheCodeController.GetShowMeTheCodeViewModel();

            Assert.IsInstanceOf(typeof(OkObjectResult), resultado);

            var okResult = resultado as OkObjectResult;

            Assert.IsTrue(okResult.StatusCode == STATUSCODESUCESSO, "O Serviço deve ser consumido com sucesso!");

            Assert.AreEqual(resultadoMock.Value.ToString(), okResult.Value.ToString(), $"A URL do projeto git deve ser {URLPROJETOGITMOCK}");
        }
    }
}