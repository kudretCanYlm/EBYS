
function openUpdateModal() {
    $('#updateModal').modal('show');
}

function closeUpdateModal() {
    $('#updateModal').modal('hide');
}

function openCreateModal() {
    $('#createModal').modal('show');
}

function closeCreateModal() {
    $('#createModal').modal('hide');
}

function deleteDepartman() {
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

function DepartmanResult(result) {
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