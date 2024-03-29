﻿using System;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoProdutoRemovidoEvent : Event
    {
        public PedidoProdutoRemovidoEvent(Guid clienteId, Guid pedidoId, Guid produtoId)
        {
            AggregateId = pedidoId;
            ClienteId = clienteId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }

        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
    }
}
