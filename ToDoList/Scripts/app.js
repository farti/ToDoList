var currentList = {};

function createNewList() {
    currentList.name = $("#newListName").val();
    currentList.items = new Array();

    // Web Service Call
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "api/ToDoList/",
        data: currentList,
        success: function (result) {
            showToDoList();
        }
    });
}

function showToDoList() {
    $("#toDoListTitle").html(currentList.name);
    $("#toDoListItems").empty();

    $("#createListDiv").hide();
    $("#toDoListDiv").show();

    $("#newItemName").focus();
    $("#newItemName").keyup(function (event) {
        if (event.keyCode == 13) {
            addItem();
        }
    });
}

function addItem() {
    var newItem = {};
    newItem.name = $("#newItemName").val();
    newItem.toDoListId = currentList.id;

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "api/Item/",
        data: newItem,
        success: function (result) {
            currentList = result;
            drawItems();
            $("#newItemName").val("");
        }
    });
}

function drawItems() {
    var $list = $("#toDoListItems").empty();

    for (var i = 0; i < currentList.items.length; i++) {
        var currentItem = currentList.items[i];
        var $li = $('<li class="list-group-item ">').html(currentItem.name)
            .attr("id", "item_" + i);
        var $deleteBtn = $("<button onclick='deleteItem(" + currentItem.id + ")' class='btn btn-danger btn-sm'>D</button>").appendTo($li);
        var $checkBtn = $("<button  onclick='checkItem(" + currentItem.id + ")' class='btn btn-success btn-sm'>C</button>").appendTo($li);

        if (currentItem.checked) {
            $li.addClass("checked");
        }

        $li.appendTo($list);
    }
}

function deleteItem(itemId) {
    $.ajax({
        type: "DELETE",
        dataType: "json",
        url: "api/Item/" + itemId,
        success: function (result) {
            currentList = result;
            drawItems();
        }
    });
}

function checkItem(itemId) {
    var changedItem = {};

    for (var i = 0; i < currentList.items.length; i++) {
        if (currentList.items[i].id == itemId) {
            changedItem = currentList.items[i];
        }
    }

    changedItem.checked = !changedItem.checked;

    $.ajax({
        type: "PUT",
        dataType: "json",
        url: "api/Item/" + itemId,
        data: changedItem,
        success: function (result) {
            currentList = result;
            drawItems();
        }
    });
}

function getToDoListById(id) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "api/ToDoList/" + id,
        success: function (result) {
            currentList = result;
            showToDoList();
            drawItems();
        }
    });
}

$(document).ready(function () {
    console.info("ready");

    $("#newListName").focus();
    $("#newListName").keyup(function (event) {
        if (event.keyCode == 13) {
            createNewList();
        }
    });


    var pageUrl = window.location.href;
    var idIndex = pageUrl.indexOf("?id=");
    if (idIndex != -1) {
        getToDoListById(pageUrl.substring(idIndex + 4));
    }
});
