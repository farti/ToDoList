var currentList = {};

function createNewList() {
    currentList.name = $("#newListName").val();
    currentList.items = new Array();
    // Web Service Call

    showToDoList();
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
    currentList.items.push(newItem);

    drawItems();

    $("#newItemName").val("");
}

function drawItems() {
    var $list = $("#toDoListItems").empty();

    for (var i = 0; i < currentList.items.length; i++) {
        var currentItem = currentList.items[i];
        var $li = $('<li class="list-group-item ">').html(currentItem.name)
            .attr("id", "item_" + i);
        var $deleteBtn = $("<button onclick='deleteItem(" + i + ")' class='btn btn-danger btn-sm'>D</button>").appendTo($li);
        var $checkBtn = $("<button  onclick='checkItem(" + i + ")' class='btn btn-success btn-sm'>C</button>").appendTo($li);

        $li.appendTo($list);
    }
}

function deleteItem(index) {
    currentList.items.splice(index, 1);
    drawItems();
}

function checkItem(index) {
    if ($("#item_" + index).hasClass("chcecked")) {
        $("#item_" + index).removeClass("chcecked");
    } else {
        $("#item_" + index).addClass("chcecked");
    }
}

function getToDoListById(id) {
    console.info(id);

    currentList.name = "Mock To Do List";
    currentList.items = [
        { name: "Milk" },
        { name: "Tomato" },
        { name: "Water" }
    ];

    showToDoList();
    drawItems();
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
