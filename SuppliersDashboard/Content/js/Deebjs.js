// ########## css classes ##########
// detail
// detail-child

// ##########  JS Methods ##########
// showModal
// endModal
// showSuccessOperation
// showDangerOperation
// log
// startLoader
// endLoader
// sure
// showDetails

// ##########  HTML Elements ##########
//   <!--this div to handle show details-->   <div class="d-none" id="style-div"> <style>.detail {display: none}td:has(.detail-child) {display: none }</style></div>   <!--this div to handle show details--> <button class="btn btn-primary" onclick="showDetails(this)"> show details</button>

"use strict";
function ShowModal(html) {
    $("#modalContainer").html(html)
    $("#modal").modal("show")
}
function showModal(html) {
    $("#modalContainer").html(html)
    $("#modal").modal("show")
}
function closepopup() {
    EndModal()
}
function closePopup() {
    EndModal()
}

function EndModal() {

    $("#modal").modal("hide")
}

function endModal() {

    $("#modal").modal("hide")
}

function showsuccessoperation(txt) {
    let html = `
    <div class=' p-4'  style='min-width:500px' >

    <div class=' p-4'>
    <div class='text-center text-success'>
    <i style='font-size:150px' class="fa fa-solid fa-check"></i>
    </div>
    </div>
    <div class='pt-3 pb-3 text-center text-success' style='font-size:20px'> ${txt}</div>
    </div>
    `
    ShowModal(html)
}
function showSuccessOperation(txt) {
    let html = `
    <div class=' p-4'  style='min-width:500px' >

    <div class=' p-4'>
     <div style='text-align:right'><button onclick='closepopup()' class='btn text-danger'> X </button></div>
    <div class='text-center text-success'>
    <i style='font-size:150px' class="fa fa-solid fa-check"></i>
    </div>
    </div>
    <div class='pt-3 pb-3 text-center text-success' style='font-size:20px'> ${txt}</div>
    </div>
    `
    ShowModal(html)
}
function showdangeroperation(txt) {
    let html = `
    <div class=' p-4' style='min-width:500px' >
    <div class=' p-4'>
     <div style='text-align:right'><button onclick='closepopup()' class='btn text-danger'> X </button></div>
    <div class='text-center text-danger'>
    <i style='font-size:50px' class="fa fa-solid fa-exclamation"></i>
    </div>
    </div>
    <div class='pt-3 pb-3 text-center text-danger' style='font-size:20px'> ${txt}</div>
    </div>
    `
    ShowModal(html)
}
function showDangerOperation(txt) {
    let html = `
    <div class=' p-4' style='min-width:500px' >
    <div class=' p-4'>
     <div style='text-align:right'><button onclick='closepopup()' class='btn text-danger'> X </button></div>
    <div class='text-center text-danger'>
    <i style='font-size:50px' class="fa fa-solid fa-exclamation"></i>
    </div>
    </div>
    <div class='pt-3 pb-3 text-center text-danger' style='font-size:20px'> ${txt}</div>
    </div>
    `
    ShowModal(html)
}
function log(x) { console.log(x) }

function StartLoader() {
    $("#Loading").modal("show")
}
function startLoader() {
    $("#Loading").modal("show")
}
function EndLoader() {

    $("#Loading").modal("hide")
}
function endLoader() {

    $("#Loading").modal("hide")
}
function sure(msg, btntxt, btnclick) {
    debugger

    let html = `
    <div  style='min-width:500px' >


    <i style='font-size:150px' class="fa fa-regular fa-circle-question"></i>
    </div>
 
    </div>
    <div class='pt-3 pb-3 text-center text-warning' style='font-size:22px;font-weight:bolder'> 
   ${msg}
     </div>
    <div class="row  d-flex justify-content-around">
    <div class="col-lg-4 text-center p-3">
   <button style='font-size: 18px;' class='btn btn-primary col-12 btn-lg ' onclick="${btnclick}">${btntxt}</button>
    </div>
    </div>
    </div>
    `
    ShowModal(html)
}
function displaymsg(msg) {
    let ht = `
        <div class='p-3 '>
        <h3 class='text-center h3  '>
        ${msg}
        <h3>
        </div>
        `
    ShowModal(ht)
}

let displaynonestyle = `
 <style>
        .detail{
            display:none
        }
        td:has(.detail-child){
            display:none
        }
    </style>     
`
let displayornot = 0;
function showDetails(ele) {

    if (displayornot == 0) {
        $("#style-div").html('')
        $(ele).text(`hide details`)
        displayornot = 1
    } else {
        $("#style-div").html(displaynonestyle)

        $(ele).text(`show details`)
        displayornot = 0
    }
}


function ddddate() {
    return new Date();
}
function getCurrentDateTime() {
    var currentdate = ddddate()
    var datetime = currentdate.getFullYear() + "-" + (currentdate.getMonth() + 1) + "-" + currentdate.getDate() + " " + currentdate.getHours() + ":" + currentdate.getMinutes() + ":" + currentdate.getSeconds();
    return datetime;
}
function getCurrentDate() {
    var currentdate = ddddate()
    var datetime = currentdate.getFullYear() + "-" + (currentdate.getMonth() + 1) + "-" + currentdate.getDate();
    return datetime;
}
function getFirstDayInMonth() {
    var currentdate = ddddate()
    var datetime = currentdate.getFullYear() + "-" + (currentdate.getMonth() + 1) + "-01";
    return datetime;
}
function getLastDayInMonth() {
    var currentdate = ddddate()
    var datetime = currentdate.getFullYear() + "-" + (currentdate.getMonth() + 1) + "-" + daysInMonth((currentdate.getMonth() + 1), currentdate.getFullYear());
    return datetime;
}
function daysInMonth(month, year) {
    return new Date(year, month, 0).getDate();
}

function Search(inputId, divclass) {
    // Declare variables

    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById(inputId);
    filter = input.value.toUpperCase();

    tr = table.getElementsByTagName(divclass);

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        let ele = tr[i]
        txtValue = ele.textContent || ele.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            ele.style.display = "";
            break;
        } else {
            ele.style.display = "none";
        }


    }
}