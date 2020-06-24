let toDoList = (function () {
    let todoApiBasePath = "/Todo";

    // todoApiBasePath = "/TodoSimple";     //uncomment for api client with si

    let $todoListAddButton = $('.todo-list-add-btn');
    let $todoListItem = $('.todo-list');

    const init = function () {
        hookEvents();
    };

    const hookEvents = function () {

        $todoListAddButton.on("click", function (event) {
            event.preventDefault();
            var name = $(this).prevAll('.todo-list-input').val();

            if (name) {
                createItem(name);
            }
        });

        $todoListItem.on('change', '.checkbox', function () {
            let details = JSON.parse(this.dataset.details);
            details.isComplete = ($(this).prop("checked") === true)
            updateItem(details);
            
        });

        $todoListItem.on('click', '.remove', function () {
            let id = this.dataset.id;
            deleteItem(id);
        });
    }

    const createItem = function (name) {
        fetch(todoApiBasePath, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json;'
            },
            body: JSON.stringify({ name: name })
        }).then(function (response) {
            location.reload();
        });
    }

    const updateItem = function (details) {
        fetch(`${todoApiBasePath}/${details.id}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json;'
            },
            body: JSON.stringify(details)
        }).then(function (response) {
            location.reload();
        });
    }

    const deleteItem = function (id) {
        fetch(`${todoApiBasePath}/${id}`, {
            method: 'delete',
        }).then(function (response) {
            location.reload();
        }).then(function (data) {
        });
    }    

    return {
        init: init
    };
})();

toDoList.init();