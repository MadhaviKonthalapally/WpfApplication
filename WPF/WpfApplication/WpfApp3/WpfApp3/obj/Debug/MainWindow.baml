   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5      � $��8,10,-8,-10q�6   .+�5   
   o� $	��Top=�6   .@�5      m� -   5        $��_Employee Details��5      5      m� 5      -   5        $��
_PaidMonth��5      5      5      �� 5   
   $��20q�6   .+�5      �� -   5        $��monthsComboBox��5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ EmployeeDataGrid��5      $
��Left=�6-   $	��491��6H   $��	10,20,0,0q�6U   $	��Top=�5      $	��741��6'      AutoGenerateColumns .  ��6O   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6<      Header$ Employee ID��6H      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *ID+6]     5      $	 100 6c   $
 Name��6o    6%   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6o     5      $	 100 6d   $ Gender��6p    6%   �� *Gender+$ PropertyChanged=�6p     5      $	 150 6d   $ Salary��6p    6%   �� *Salary+$ PropertyChanged=�6p     5      $	 100 6e   $ PayDate��6q    6%   �� *	PayDate+$ PropertyChanged=�6q   5!        5"   
   -   5        $ SalaryDataGrid��5"      $
��Left=�6+   $
��Auto��6F   $��	10,50,0,0q�6T   $	��Top=�5#      $
��Auto��6'    .  ��6P   ��  5$        5%      $	 100 6c   $
 Name��6o    6%   �� *Name+$ PropertyChanged=�6o     5&      $	 100 6g   $ 
Paid Month��6s    6%   �� *	PaidMonth+$ PropertyChanged=�6s     5'      $	 150 6h   $ Paid Amount��6t    6%   �� *
PaidAmount+$ PropertyChanged=�6t   5)      5*      5+      