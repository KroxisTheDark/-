namespace GreengroceryStore
{
    partial class Graph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.продуктBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.greengrocery_storeDataSet = new GreengroceryStore.greengrocery_storeDataSet();
            this.продуктTableAdapter = new GreengroceryStore.greengrocery_storeDataSetTableAdapters.ПродуктTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.названиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоНаСкладеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.продуктBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.greengrocery_storeDataSet1 = new GreengroceryStore.greengrocery_storeDataSet1();
            this.продуктBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.продуктTableAdapter1 = new GreengroceryStore.greengrocery_storeDataSet1TableAdapters.ПродуктTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.продуктBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greengrocery_storeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.продуктBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greengrocery_storeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.продуктBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.продуктBindingSource2;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 13);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Количество товаров на складе";
            series1.XValueMember = "Название";
            series1.YValueMembers = "КоличествоНаСкладе";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1129, 497);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // продуктBindingSource
            // 
            this.продуктBindingSource.DataMember = "Продукт";
            this.продуктBindingSource.DataSource = this.greengrocery_storeDataSet;
            // 
            // greengrocery_storeDataSet
            // 
            this.greengrocery_storeDataSet.DataSetName = "greengrocery_storeDataSet";
            this.greengrocery_storeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // продуктTableAdapter
            // 
            this.продуктTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.названиеDataGridViewTextBoxColumn,
            this.количествоНаСкладеDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.продуктBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 517);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1129, 283);
            this.dataGridView1.TabIndex = 3;
            // 
            // названиеDataGridViewTextBoxColumn
            // 
            this.названиеDataGridViewTextBoxColumn.DataPropertyName = "Название";
            this.названиеDataGridViewTextBoxColumn.HeaderText = "Название";
            this.названиеDataGridViewTextBoxColumn.Name = "названиеDataGridViewTextBoxColumn";
            // 
            // количествоНаСкладеDataGridViewTextBoxColumn
            // 
            this.количествоНаСкладеDataGridViewTextBoxColumn.DataPropertyName = "КоличествоНаСкладе";
            this.количествоНаСкладеDataGridViewTextBoxColumn.HeaderText = "КоличествоНаСкладе";
            this.количествоНаСкладеDataGridViewTextBoxColumn.Name = "количествоНаСкладеDataGridViewTextBoxColumn";
            // 
            // продуктBindingSource1
            // 
            this.продуктBindingSource1.DataMember = "Продукт";
            this.продуктBindingSource1.DataSource = this.greengrocery_storeDataSet;
            // 
            // greengrocery_storeDataSet1
            // 
            this.greengrocery_storeDataSet1.DataSetName = "greengrocery_storeDataSet1";
            this.greengrocery_storeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // продуктBindingSource2
            // 
            this.продуктBindingSource2.DataMember = "Продукт";
            this.продуктBindingSource2.DataSource = this.greengrocery_storeDataSet1;
            // 
            // продуктTableAdapter1
            // 
            this.продуктTableAdapter1.ClearBeforeFill = true;
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 766);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Graph";
            this.Text = "График";
            this.Load += new System.EventHandler(this.Graph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.продуктBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greengrocery_storeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.продуктBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greengrocery_storeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.продуктBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private greengrocery_storeDataSet greengrocery_storeDataSet;
        private System.Windows.Forms.BindingSource продуктBindingSource;
        private greengrocery_storeDataSetTableAdapters.ПродуктTableAdapter продуктTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоНаСкладеDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource продуктBindingSource1;
        private greengrocery_storeDataSet1 greengrocery_storeDataSet1;
        private System.Windows.Forms.BindingSource продуктBindingSource2;
        private greengrocery_storeDataSet1TableAdapters.ПродуктTableAdapter продуктTableAdapter1;
    }
}