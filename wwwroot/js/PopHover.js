function printApplication(appno, opt) {
    var win = window.open('PrintAdmission?appNo=' + appno + '&Option=' + opt, null, 'width=0,height=0');
    win.onload = function () {
        win.print();
    }
}

//$(document).ready(function () {
//    $('[data-toggle="popover"]').popover({
//        placement: 'right',
//        trigger: 'hover',
//        html: true,
//        title: '<button type="button" class="btn btn-primary glyphicon glyphicon-print" onclick="printApplication(1212162612,1)" data-dismiss="modal">Admission</button>',
//        content: '<button type="button" class="btn btn-primary glyphicon glyphicon-print" onclick="printApplication(1212162612,1)" data-dismiss="modal">Admission</button>'
//    });
//});


var originalLeave = $.fn.popover.Constructor.prototype.leave;
$.fn.popover.Constructor.prototype.leave = function (obj) {
    var self = obj instanceof this.constructor ?
        obj : $(obj.currentTarget)[this.type](this.getDelegateOptions()).data('bs.' + this.type)
    var container, timeout;

    originalLeave.call(this, obj);

    if (obj.currentTarget) {
        container = $(obj.currentTarget).siblings('.popover')
        timeout = self.timeout;
        container.one('mouseenter', function () {
            //We entered the actual popover – call off the dogs
            clearTimeout(timeout);
            //Let's monitor popover content instead
            container.one('mouseleave', function () {
                $.fn.popover.Constructor.prototype.leave.call(self, self);
            });
        })
    }
};

$('body').popover({ selector: '[data-popover]', trigger: 'click hover', delay: { show: 50, hide: 400 } });


function ChangeSelection() {
    $("#Form").submit();
}

function ChangePage(page) {
    $("#page").val(page);
    $("#Form").submit();
}
$(document).ready(function () {
    var x = $("#SelectedGroup").val();
    if (x != "") {
        $("#Group").val(x);
    }
    $("#pageSize").val($("#SelectedPageSize").val());
})




function open_panel() {
    slideIt();
    var a = document.getElementById("sidebar");
    a.setAttribute("id", "sidebar1");
    a.setAttribute("onclick", "close_panel()");
}

function slideIt() {
    var slidingDiv = document.getElementById("slider");
    var stopPosition = 0;
    if (parseInt(slidingDiv.style.right) < stopPosition) {
        slidingDiv.style.right = parseInt(slidingDiv.style.right) + 2 + "px";
        setTimeout(slideIt, 1);
    }
}

function close_panel() {
    slideIn();
    a = document.getElementById("sidebar1");
    a.setAttribute("id", "sidebar");
    a.setAttribute("onclick", "open_panel()");
}

function slideIn() {
    var slidingDiv = document.getElementById("slider");
    var stopPosition = -342;
    if (parseInt(slidingDiv.style.right) > stopPosition) {
        slidingDiv.style.right = parseInt(slidingDiv.style.right) - 2 + "px";
        setTimeout(slideIn, 1);
    }
}

function hideAppNo(value) {
    if (value == "1") {
        document.getElementById("appno").style.display = "block";
        document.getElementById("subject").style.display = "block";
        document.getElementById("Groups").style.display = "none";
    }
    else if (value == "2") {
        document.getElementById("appno").style.display = "none";
        document.getElementById("subject").style.display = "block";
        document.getElementById("Groups").style.display = "block";
    }
    else if (value == "3") {
        document.getElementById("appno").style.display = "none";
        document.getElementById("subject").style.display = "block";
        document.getElementById("Groups").style.display = "none";
    }
}