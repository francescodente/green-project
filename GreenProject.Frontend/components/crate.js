class Crate extends Purchasable {

    constructor(json, occupiedSlots, orderDetailId) {
        super(json);
        this.occupiedSlots = occupiedSlots;
        this.orderDetailId = orderDetailId;
        if (this.itemId != null) this.crateId = this.itemId;

        // Add templates
        this.html.main = Entity.getTemplate("CrateCard");
        this.html.weeklyEntry = Entity.getTemplate("CrateWeeklyEntry");
        this.html.orderEntry = Entity.getTemplate("CrateOrderEntry");
        this.html.deliveryEntry = Entity.getTemplate("CrateDeliveryEntry");
        this.html.detailsModal = Entity.getTemplate("CrateDetailsModal");
        this.html.removeModal = Entity.getTemplate("CrateRemoveModal");

        let crate = this;
        let imageUrl = API.basePath + this.imageUrl;
        let price = Utils.formatCurrency(this.price);
        let capacity = Utils.formatDecimal(this.capacity / 2, "auto");
        if (occupiedSlots != null) {
            capacity = Utils.formatDecimal(occupiedSlots / 2, "auto") + "/" + capacity;
        }

        for (let k in crate.html) {

            // Init tooltips
            $(crate.html[k]).find('[data-tooltip="tooltip"]').tooltip();

            // Replace values in templates
            if (occupiedSlots == 0) {
                $(crate.html[k]).find(".crate-name").html(this.name + " (vuota)");
            } else {
                $(crate.html[k]).find(".crate-name").html(this.name);
            }
            $(crate.html[k]).find(".crate-description").html(this.description);
            if (this.imageUrl != null) {
                $(crate.html[k]).find(".crate-image").attr("src", imageUrl);
                $(crate.html[k]).find(".crate-image").attr("alt", this.name);
            }
            $(crate.html[k]).find(".capacity").html(capacity);
            $(crate.html[k]).find(".price").html(price);

            // Add event listeners
            $(crate.html[k]).find(".crate-modal-link").click(function(e) {
                e.preventDefault();
                crate.showDetailsModal();
            });
            $(crate.html[k]).find(".subscribe").click(function() { crate.addToPreferences(); });
            $(crate.html[k]).find(".show-remove-modal").click(function(event) {
                event.preventDefault();
                event.stopPropagation();
                crate.showRemoveModal();
            });
            $(crate.html[k]).find(".remove-from-preferences").click(function() { crate.removeFromPreferences(); });
        }
    }

    showDetailsModal() {
        this.html.detailsModal.showModal();
    }

    addToPreferences() {
        let authData = localStorage.getObject("authData");
        if (authData === null) {
            new InfoModal("Devi essere registrato e aver effettuato l'accesso per abbonarti a una cassetta settimanale.").show();
            return;
        }
        console.log("add to preferences " + this.crateId);
        $("#modal-loading").showModal();
        APIUtils.addWeeklyCrate(this)
        .then(function(data) { console.log(data); $("#crate-added-modal").showModal() })
        .catch(function(jqXHR) { console.log(jqXHR); new ErrorModal(jqXHR).show() });
    }

    showRemoveModal() {
        this.html.removeModal.showModal();
    }

    removeFromPreferences() {
        console.log("remove from preferences " + this.crateId);
        APIUtils.removeFromWeeklyOrder(this.orderDetailId)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
    }

}
