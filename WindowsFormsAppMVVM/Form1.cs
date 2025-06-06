using System;
using System.Windows.Forms;

namespace WindowsFormsAppMVVM
{
    public partial class Form1 : Form
    {
        private readonly CounterViewModel _viewModel = new CounterViewModel();

        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonIncrement;
        private System.Windows.Forms.BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();

            var bindingSource = new BindingSource { DataSource = _viewModel };
            
            labelCount.DataBindings.Add("Text", bindingSource, "Count", true, DataSourceUpdateMode.OnPropertyChanged);

            buttonIncrement.Click += (_, __) => _viewModel.Increment();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
