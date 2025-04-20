//using gestorPedido.Domain.Entities;
//using gestorPedido.Domain.Validators;
//using System;
//using Xunit;

//namespace gestorPedidos.Tests.Validators
//{
//    public class PedidoValidatorTests
//    {
//        [Fact]
//        public void PedidoValido_DeveSerValido()
//        {
//            // Arrange
//            var pedido = new Pedido(Guid.NewGuid(), DateTime.Now);
//            var validator = new PedidoValidator();

//            // Act
//            var resultado = validator.Validate(pedido);

//            // Assert
//            Assert.True(resultado.IsValid);
//        }

//        [Fact]
//        public void PedidoComRevendaIdVazio_DeveSerInvalido()
//        {
//            // Arrange
//            var pedido = new Pedido(Guid.Empty, DateTime.Now);
//            var validator = new PedidoValidator();

//            // Act
//            var resultado = validator.Validate(pedido);

//            // Assert
//            Assert.False(resultado.IsValid);
//            Assert.Contains(resultado.Errors, e => e.PropertyName == "RevendaId");
//        }
//    }
//}
