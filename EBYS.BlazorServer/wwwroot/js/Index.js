function redirectToLogin()
{
    document.cookie = ".AspNetCore.Cookies"+ "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";

    window.location.href = "/giris";
}
function openUpdateModal() {
    $('#updateModal').modal('show');
}

function closeUpdateModal() {
    $('#updateModal').modal('hide');
}

function addDataTable() {

    $('#myDataTable').DataTable();
}


function openCreateModal() {
    $('#createModal').modal('show');
}

function closeCreateModal() {
    $('#createModal').modal('hide');
}

function deletePopUp() {
    return Swal.fire({
        title: "Emin misiniz?",
        text: "Silmek istediğinizden emin misiniz?",
        icon: "question",
        showCancelButton: true,
        confirmButtonText: "Onayla",
        cancelButtonText: "İptal",
    }).then((result) => {
        return result.isConfirmed
    });
}

function resultPopUp(result) {
    if (result == true) {
        Swal.fire({
            title: "Bilgi",
            text: "İşlem başarılı",
            icon: "info",
            confirmButtonText: "Tamam",
        });
    }
    else {
        Swal.fire({
            title: "Hata",
            text: "Bir hata oluştu.",
            icon: "error",
            confirmButtonText: "Tamam",
        });
    }

}

function DrawPie()
{
    // Verileri tanımlayın
    var veriler = {
        labels: ['Tamamlanan', 'Tamamlanmayan'],
        datasets: [{
            data: [60, 30],
            backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0']
        }]
    };

    // Yapılandırmaları tanımlayın
    var yapilandirmalar = {
        responsive: true
    };

    // Pasta grafiğini çizin
    var pastaGrafigi = new Chart(document.getElementById('pastaGrafigi'), {
        type: 'pie',
        data: veriler,
        options: yapilandirmalar
    });
}