﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM.UI;
using QLNS.UI.ViewModels;
using DevExpress.XtraGrid.Views.Base;
using QLNS.UI.Helper;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using QLNS.Service;
using QLNS.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout.Events;
using DevExpress.XtraGrid.Views.Layout;

namespace QLNS.UI.Views.Employee
{
    [ViewType("EmployeeCollectionView")]
    public partial class EmployeesView : UserControl
    {
        public EmployeesView()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                InitBindings();
            }

        }

        private void InitBindings()
        {
            var fluent = mvvmContext1.OfType<EmployeeCollectionViewModel>();
            //fluent.SetBinding(cardView1, gView => gView.LoadingPanelVisible, x => x.IsLoading);
            fluent.SetBinding(gridControl1, gControl => gControl.DataSource, x => x.Entities);
            fluent.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(cardView1, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity,
                args => args.Row as QLNS.Model.Models.Employee,
                (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
            //fluent.WithEvent<RowCellClickEventArgs>(gridView1, "RowCellClick")
            //    .EventToCommand(
            //        x => x.Edit(null), x => x.SelectedEntity, args => (args.Clicks == 2) && (args.Button == MouseButtons.Left));
            List<string> listClHide = new List<string> { "Email",
                "DateOfBirth",
                "Gender",
                "Phone",
                "IDCardNo",
                "DateIssued",
                "PlaceIssued",
                "DepartmentId",
                "LeaderId",
                "PositionId"
            };
            //GridViewHelper.ShowOrHideGridViewColumns(cardView1, listClHide, false);
            GridColumn gc = cardView1.Columns["Department"];
            RepositoryItemLookUpEdit lookUpEdit = new RepositoryItemLookUpEdit() { };
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "Department" && e.Value != null)
            {
                QLNS.Model.Models.Department department = e.Value as QLNS.Model.Models.Department;
                e.DisplayText = department.Name;
            }
            if (e.Column.FieldName == "Position" && e.Value != null)
            {
                QLNS.Model.Models.Position pos = e.Value as QLNS.Model.Models.Position;
                e.DisplayText = pos.Name;
            }
            if (e.Column.FieldName == "Leader" && e.Value != null)
            {
                QLNS.Model.Models.Employee leader = e.Value as QLNS.Model.Models.Employee;
                e.DisplayText = leader.Name;
            }
        }
    }
}
