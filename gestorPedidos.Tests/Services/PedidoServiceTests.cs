//using gestorPedido.Application.Services;
//using gestorPedido.Domain.Entities;
//using gestorPedido.Domain.Interfaces;
//using Moq;
//using System;
//using System.Collections.Generic;
//using Xunit;

//namespace gestorPedidos.Tests.Services
//{
//    public class PedidoServiceTests
//    {
//        [Fact]
//        public void DeveCriarPedidoComSucesso()
//        {
//            // Arrange
//            var mockRepo = new Mock<IPedidoRepository>();
//            var service = new PedidoService(mockRepo.Object);

//            var pedido = new Pedido(Guid.NewGuid(), DateTime.Now);

//            // Act
//            service.CriarPedido(pedido);

//            // Assert
//            mockRepo.Verify(r => r.Adicionar(pedido), Times.Once);
//        }

//        [Fact]
//        public void DeveObterTodosPedidos()
//        {
//            // Arrange
//            var pedidos = new List<Pedido>
//            {
//                new Pedido(Guid.NewGuid(), DateTime.Now)
//            };

//            var mockRepo = new Mock<IPedidoRepository>();
//            mockRepo.Setup(r => r.ObterTodos()).Returns(pedidos);

//            var service = new PedidoService(mockRepo.Object);

//            // Act
//            var resultado = service.ObterPedidos();

//            // Assert
//            Assert.Single(resultado);
//        }
//    }
//}
