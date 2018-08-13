function showDatePicker(compomentId) {
    $(compomentId).datetimepicker({
        format: 'dd-mm-yyyy HH:ii:ss P',
        showMeridian: true,
        autoclose: true,
        todayBtn: true       
    });
}