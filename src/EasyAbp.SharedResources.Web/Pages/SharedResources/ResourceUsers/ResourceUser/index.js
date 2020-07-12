$(function () {

    var l = abp.localization.getResource('SharedResources');

    var service = easyAbp.sharedResources.resourceUsers.resourceUser;
    var createModal = new abp.ModalManager(abp.appPath + 'SharedResources/ResourceUsers/ResourceUser/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'SharedResources/ResourceUsers/ResourceUser/EditModal');

    var dataTable = $('#ResourceUserTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, function () {
            return { resourceId: resourceId };
        }),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('EasyAbp.SharedResources.ResourceUser.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyAbp.SharedResources.ResourceUser.Delete'),
                                confirmMessage: function (data) {
                                    return l('ResourceUserDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            { data: "userId" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewResourceUserButton').click(function (e) {
        e.preventDefault();
        createModal.open({ resourceId: resourceId });
    });
});