   M S B A M L   `   `   `  ����   Password Manager&     Account_Manager.Views.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � WindowStartupLocation$  CenterScreen=�$y�Visible=�$	��700��$
��1366��$
��1000�� � WindowState$ 	Maximized=�.���� $	��Top=�.+�o� $
��Auto��$��20��.@�m� $��_File��.@�m� -    m�Name$ Add_Account��$��_Add New��$
��Left=�$	��140�� m� Command �� *
AddCommand+m� -   $ About��$��About��$
��Left=�$��50�� �� *AboutCommand+�� $��Update��$	��100��$��20��
�������$��0 10 0 0q�$��Center=����� *UpdateCommand+&   System.Windows.Controls.DataGrid  -   $��DataGridAccounts��$��10 10 10 10q�   AutoGenerateColumns .   �� AlternationCount$ 2��   AlternatingRowBackground
 �����   CanUserAddRows .  $��18(�$	��550��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * ���� *
Accounts+	 �� Mode$	 OneWay=�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Username��   Width$	 300 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Username+$	 TwoWay=�   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property �@�ToolTip �� Value �� *AdditionalInfo+  $ Password��$	 300  �� *
Password+$	 OneWay=�  $ Email Address��$	 300  �� *Email+$	 OneWay=�5  /System.Windows.Controls.DataGridHyperlinkColumn  $ Account Source��$ *  �� *AccountSource+$	 OneWay=�