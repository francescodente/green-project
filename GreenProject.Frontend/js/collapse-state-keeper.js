$("body").on("show.bs.collapse", function(e) {
    let shownCollapses = localStorage.getObject("shownCollapses");
    shownCollapses = shownCollapses == null ? new Set() : new Set(shownCollapses);
    shownCollapses.add($(e.target).attr("id"));
    localStorage.setObject("shownCollapses", [...shownCollapses]);
});

$("body").on("hide.bs.collapse", function(e) {
    let shownCollapses = localStorage.getObject("shownCollapses");
    if (shownCollapses == null) return;
    shownCollapses = new Set(shownCollapses);
    shownCollapses.delete($(e.target).attr("id"));
    localStorage.setObject("shownCollapses", [...shownCollapses]);
});

function loadCollapseStates() {
    let shownCollapses = localStorage.getObject("shownCollapses");
    if (shownCollapses == null) return;
    shownCollapses.forEach(collapseId => $("#" + collapseId).collapse("show"));
}

$(document).ready(function() { loadCollapseStates() });