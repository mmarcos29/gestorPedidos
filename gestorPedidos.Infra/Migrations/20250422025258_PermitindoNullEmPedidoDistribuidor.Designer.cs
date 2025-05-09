﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gestorPedidos.Infra.Context;

#nullable disable

namespace gestorPedidos.Infra.Migrations
{
    [DbContext(typeof(GestorPedidosDbContext))]
    [Migration("20250422025258_PermitindoNullEmPedidoDistribuidor")]
    partial class PermitindoNullEmPedidoDistribuidor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gestorPedido.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RevendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RevendaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Principal")
                        .HasColumnType("bit");

                    b.Property<int?>("RevendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("RevendaId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RevendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("RevendaId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PedidoDistribuidorId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoDistribuidorId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RevendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("RevendaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.PedidoDistribuidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Retorno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RevendaId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("Sucesso")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RevendaId");

                    b.ToTable("PedidoDistribuidores");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Revenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("Revendas");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContatoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("gestorPedido.Domain.Entities.Revenda", "Revenda")
                        .WithMany("Clientes")
                        .HasForeignKey("RevendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Revenda");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Contato", b =>
                {
                    b.HasOne("gestorPedido.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Contatos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("gestorPedido.Domain.Entities.Revenda", "Revenda")
                        .WithMany("Contatos")
                        .HasForeignKey("RevendaId");

                    b.Navigation("Cliente");

                    b.Navigation("Revenda");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("gestorPedido.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("gestorPedido.Domain.Entities.Revenda", "Revenda")
                        .WithMany("Enderecos")
                        .HasForeignKey("RevendaId");

                    b.Navigation("Cliente");

                    b.Navigation("Revenda");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.ItemPedido", b =>
                {
                    b.HasOne("gestorPedido.Domain.Entities.PedidoDistribuidor", null)
                        .WithMany("Itens")
                        .HasForeignKey("PedidoDistribuidorId");

                    b.HasOne("gestorPedido.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gestorPedido.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("gestorPedido.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gestorPedido.Domain.Entities.Revenda", "Revenda")
                        .WithMany("Pedidos")
                        .HasForeignKey("RevendaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Revenda");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.PedidoDistribuidor", b =>
                {
                    b.HasOne("gestorPedido.Domain.Entities.Revenda", "Revenda")
                        .WithMany()
                        .HasForeignKey("RevendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Revenda");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Telefone", b =>
                {
                    b.HasOne("gestorPedido.Domain.Entities.Contato", "Contato")
                        .WithMany("Telefones")
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Enderecos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Contato", b =>
                {
                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.PedidoDistribuidor", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("gestorPedido.Domain.Entities.Revenda", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Contatos");

                    b.Navigation("Enderecos");

                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
