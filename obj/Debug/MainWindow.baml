   M S B A M L   `   `   `  ����
  DemoEx    DemoEx.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  DemoEx��5   	   $	��400��6   $	��500��6%    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $%��Список элементов��6   $��16(�6,   $
��Bold"�6:   $��0,0,0,10q�6L   �� 5   
   -   5         ��Name$ ItemListBox��5      $��1��5      $��0,0,0,10q�5       �� SelectionMode$ Extended=�5       �� DisplayMemberPath$
 Text��5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��0,10,0,0q�6X   .+�5      �� -   5        $��Добавить��5      $��80��6(   $��5q�63   6>   �� 5      -   5        $��Изменить��5      $��80��6(   $��5q�63   6>   �� 5      -   5        $��Удалить��5      $��80��6'   $��5q�62   6=   �� 5      -   5        $��Очистить��5      $��80��6(   $��5q�63   6>   5      5      5       