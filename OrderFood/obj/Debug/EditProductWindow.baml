   M S B A M L   `   `   `  ����D  @OrderFood, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:OrderFood	OrderFood  5   	   !    OrderFood.EditProductWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:OrderFood     5   	     � Title$!  Изменить блюдо��5   	   ���	#FFEAEAEA � WindowStartupLocation$ CenterScreen=�5	   	   $	��250��5
   	   $	��400��6    � 	Resources 5       �� 
TargetType   	Textboxes �� Property �� Value �� 
TargetType �Name J� SnapsToDevicePixels	 ��Name
 �� CornerRadius ��Name��%R  &	        �� 5   
   " ��6   .�5      ��  � ��$ 15(�6)   �� 5       � ��$ 0q�60   �� 5       � ��$ Center=�62   �� 5       � �� 5      �� 5      " ��6&   .R�5      � $
 root��6   #��z��5      #��z��5   %    . .+�5      �� $	 
background��6%   $
 6��69   
����������	#FFABADB3$��2q�5   %   #��z��5   %   #��z��5    %   �� 5"      $ PART_ContentHost��6+   $��1q�5#   +   
������ #��z��5%   +   ��.  $��6,5,0,6q�5'   +   $��15(�5(   +   #��z��5)   +   5*      5+      5-      5.      5/      .��51      (�  (� Stretch$ Uniform=�52   	   .��54   
   �  � ColumnDefinitions 55      �� 56      $	��51* �6#   �� 57      $
��225* �6#   �� 58      $
��124* �6#    � RowDefinitions 5:      �� 5;      $	��76* �6    �� 5<      $	��41* �6    �� 5=      $
��117* �6    .+�5@      �� -   5         ��Name$ nameProduct��5E      $��10q�5B      $��1��5C      $��1��5D      #��[  5F      $��31��60   ��5A      �� *Name+5F   0   �� 5H      -   5         ��Name$ cbUnit��5L      $��1��5I      $��2��5J      $	��100��5K      $��25��5M       �� DisplayMemberPath$
 Name��5N      $��8q�5O      �� 5Q       �� Orientation$ 
Horizontal=�5R      $��2��5S      $��1��5T      .+�5U      �� -   5        $��
Назад��5V      $��10q�5W      $	��100��5X      $��30��5Y      $	��Top=�5[        
ExitButton#��[ 5\      �� 5]      -   5        $��Изменить��5^      $	��100��5_      $��
0,10,10,10q�5`      $��30��5a      $	��Top=�5c        
NextButton#��[ 5d      5e      5f      5g      5h      