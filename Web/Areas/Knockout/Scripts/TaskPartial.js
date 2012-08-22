


$(function () {


    function Task(data) {
        this.title = ko.observable(data.title);
        this.isDone = ko.observable(data.isDone);
    }

    function TaskListViewModel() {
        // Data
        var self = this;
        self.tasks = ko.observableArray([]);
        self.newTaskText = ko.observable();
        self.incompleteTasks = ko.computed(function () {
            return ko.utils.arrayFilter(self.tasks(), function (task) { return !task.isDone() && !task._destroy; });
        });
        self.existingTasks = ko.computed(function () {
            return ko.utils.arrayFilter(self.tasks(), function (task) { return !task._destroy; });
        });


        // Operations
        self.addTask = function () {
            self.tasks.push(new Task({ title: this.newTaskText() }));
            self.newTaskText("");
        };
        self.removeTask = function (task) { self.tasks.destroy(task); };
        self.save = function () {
            $('#TaskPartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            $.ajax("/Knockout/Main/SaveTasks", {
                data: ko.toJSON({ tasks: self.existingTasks }),
                type: "post", contentType: "application/json",
                success: function (result) { alert(result);  },
                error: function () { alert('error'); },
                complete: function () { $('#TaskPartial').unblock(); }
            });
        };
        self.cancel = function () {
            self.load();
        };
        self.load = function () {
            $('#TaskPartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            // Load initial state from server, convert it to Task instances, then populate self.tasks 
            $.getJSON("/Knockout/Main/GetTasks", function (allData) {
                $('#TaskPartial').unblock();
                var mappedTasks = $.map(allData, function (item) { return new Task(item); }
                );
                self.tasks(mappedTasks);
            });
        };
        self.load();
    }
    ko.applyBindings(new TaskListViewModel(), $('#TaskPartial')[0]);



});

