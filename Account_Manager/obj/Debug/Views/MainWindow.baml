   M S B A M L   `   `   `  ����  Account Manager&     Account_Manager.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6H   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6�   @d2http://schemas.microsoft.com/expression/blend/2008     6�   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   -   5          �Name$  
mainWindow��5   	    � WindowStartupLocation$ CenterScreen=�6V  $y�Visible=�6{  $	��700��6�  $
��1366��6�  $
��1000��6�   � WindowState$ 	Maximized=�6�  ���	#FF9A9EB0.��5      �� $	��Top=�6   .+�5   
   o� $
��Auto��6   $��20��6   .@�5      m� -   5         m�Name$ Add_Account��5      $��_Add New��6,   $
��Left=�6>   $��60��6Y    m� Command 6d   �� *LoadAddAccountWinCommand+m� 5      -   5        $ Update��5      $��_Update��6'   $��50��68    6C   �� *UpdateAccountListCommand+m� 5      -   5        $ About��5      $��_About��6&   $
��Left=�66   $��50��6Q    6\   �� *AboutCommand+m� 5      -   5        $ Logout��5      $��_Logout��6'   $��50��68    6C   �� *LogoutCommand+ m� CommandParameter 6e   ��  �� ElementName$ 
mainWindow��5	      &   System.Windows.Controls.DataGrid  5   
   -   5        $��DataGridAccounts��5   x   $��0q�6   $��5 5 5 5q�6'      
IsReadOnly .    AutoGenerateColumns .  	 �� AlternationCount$	 2��6�   
   AlternatingRowBackground

 �����   CanUserAddRows .  $��15(�6�   $	��680��6  $	��680��6     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6+   � UseLayoutRounding .  $
��Bold"�6U  ���	#FF9A9EB0   GridLinesVisibility$
 None=�6~     AreRowDetailsFrozen .    SelectionMode$ Single=�6�     SelectionUnit$
 Cell=�6�  ��68   �� *
Accounts+ �� Mode$ OneWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Username��6%      Width$ * 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
Username+$ TwoWay=�   	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .�5      ��  �� Property �@�ToolTip �� Value 68   �� *AdditionalInfo+5      5        5      $ Password��6%   $ * 6a    67   �� *
Password+$ OneWay=�6a     5      $ Email Address��6%   $ * 6c    6<   �� *Email+$ OneWay=�6c     5      $ Account Source��6%   $ * 6l    6=   �� *AccountSource+$ OneWay=�6l   5      5      5      