$(function () {

    var l = abp.localization.getResource('SharedResources');

    var service = easyAbp.sharedResources.resources.resource;
    var createModal = new abp.ModalManager(abp.appPath + 'SharedResources/Resources/Resource/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'SharedResources/Resources/Resource/EditModal');

    var dataTable = $('#ResourceTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, function () {
            return { categoryId: categoryId };
        }),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('ResourceItem'),
                                action: function (data) {
                                    document.location.href = document.location.origin + '/SharedResources/ResourceItems/ResourceItem?ResourceId=' + data.record.id;
                                }
                            },
                            {
                                text: l('ResourceUser'),
                                action: function (data) {
                                    document.location.href = document.location.origin + '/SharedResources/ResourceUsers/ResourceUser?ResourceId=' + data.record.id;
                                }
                            },
                            {
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('ResourceDeletionConfirmationMessage', data.record.id);
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
            { data: "categoryId" },
            { data: "name" },
            { data: "description" },
            { data: "previewMediaResources" },
            { data: "isPublished" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewResourceButton').click(function (e) {
        e.preventDefault();
        createModal.open({ categoryId: categoryId });
    });
});