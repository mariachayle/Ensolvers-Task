//table
$(document).ready(function () {


  $.ajax({
    url: "https://localhost:5001/Task/GetList",
    type: "GET",

    success: function (result) {
      if (result.ok) {
        createTable(result.return);
      }
      else {
        Swal.fire(result.error);
      }
    },
    error: function (error) {
      console.log(error);
    }
  });
})


function createTable(data) {
  for (var i = 0; i < data.length; i++) {
    var html = "<tr>";
    // html += "<td>" + data[i].id + "</td>";
    html += "<td>" + data[i].task + "</td>";
    if (data[i].done) {
      html += "<td>" + "Yes" + "</td>";
    }
    else {
      html += "<td>" + "No" + "</td>";
    }
    html += "<td>" +
      "<button type='hidden button' class='btn btn-warning' id='btnEdit' onclick='updateTask(" + data[i].id + ")'>Edit</button>" +
      "<button type='button' class='btn btn-danger' id='btnDelete' onclick='deleteTask(" + data[i].id + ")'>Delete</button>" + "</td>";

    html += "</tr>";
    $("#tablebody").append(html);
  }
}





//Update

$('#btnSaveEdit').click(function () {
  let id = $("#txtId").val();
  let task = $("#txtTask").val();
  let done = $("#txtDone").val();
  if (task === "") {
    swal("Task is requiered");
  } else {
    updateTask(id, task, done);
  }
});

function updateTask(id, task, done) {
  command = {
    "id": parseInt(id),
    "task": task,
    "done": done
  };

  $.ajax({
    url: "https://localhost:5001/Task/UpdateTask" + id,
    type: "POST",
    dataType: 'JSON',
    contentType: 'application/json',
    data: JSON.stringify(command),
    success: function (result) {
      if (result.ok) {
        swal("Update successful");
        // reload pagina
        setTimeout(function () { location.reload(); }, 3000);
      } else {
        swal("Server Problem");
      }
    },
    error: function (error) {
      swal("Server Problem");
    },
  })

}


//DELETE
$("#btnDelete").click(function () {
  let id = $("#txtId").val();
  if (id == "") {
    swal("Please select the task to eliminate");
  } else {
    deleteTask(id);
  }
});

function deleteTask(id) {
  $.ajax({
    url: "https://localhost:5001/Task/Delete/" + id,
    type: "DELETE",
    dataType: 'JSON',
    contentType: 'application/json',
    //  data: JSON.stringify(command),
    success: function (result) {
      if (result.ok) {
        swal("Delete successful");

      } else {
        swal("Server Problem");
      }
    },
    error: function (error) {
      swal("Server Problems");
    },
  })
}

//CREATE
$('#btnAdd').click(function () {

  let task = $("#txtTask").val();

  let done = checkBool($("#txtDone").val());

  function checkBool(done) {
    if (done == "yes") {
      return true;
    }
    else {
      return false;
    }
  }

  if (task === "") {
    Swal.fire("please complete the fields");
  }
  else {
    create(task, done);
  }
});

function create(task, done) {
  command = {
    "task": task,
    "done": done
  };

  $.ajax({
    url: "https://localhost:5001/Task/NewTask",
    type: "POST",
    dataType: 'JSON',
    contentType: 'application/json',
    data: JSON.stringify(command),

    success: function (result) {
      if (result.ok) {
        Swal.fire("creation successful");
      }
      else {
        Swal.fire(result.error);
      }
    },
    error: function (error) {
      console.log(error);
    }
  });
}



