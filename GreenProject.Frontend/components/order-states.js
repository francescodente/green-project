const OrderStates = [
    {
        name: "Pending",
        html: `
            <i class="order-pending mdi small mdi-progress-clock mr-2"></i>
            <span class="order-pending">In attesa</span>
        `
    },
    {
        name: "Shipping",
        html: `
            <i class="order-shipped mdi small mdi-truck-delivery-outline mr-2"></i>
            <span class="order-shipped">Spedito</span>
        `
    },
    {
        name: "Completed",
        html: `
            <i class="order-ok mdi small mdi-check-circle-outline mr-2"></i>
            <span class="order-ok">Completato</span>
        `
    },
    {
        name: "Canceled",
        html: `
            <i class="order-canceled mdi small mdi-close-circle-outline mr-2"></i>
            <span class="order-canceled">Annullato</span>
        `
    }
];