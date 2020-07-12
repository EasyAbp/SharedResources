$(function () {

    var l = abp.localization.getResource('SharedResources');

    var service = easyAbp.sharedResources.resourceItems.resourceItem;
    var createModal = new abp.ModalManager(abp.appPath + 'SharedResources/ResourceItems/ResourceItem/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'SharedResources/ResourceItems/ResourceItem/EditModal');

    var dataTable = $('#ResourceItemTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('EasyAbp.SharedResources.Resource.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyAbp.SharedResources.Resource.Delete'),
                                confirmMessage: function (data) {
                                    return l('ResourceItemDeletionConfirmationMessage', data.record.id);
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
            { data: "name" },
            { data: "isPublished" },
            { data: "isPublic" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewResourceItemButton').click(function (e) {
        e.preventDefault();
        createModal.open({ resourceId: resourceId });
    });
});