   M S B A M L   `   `   `  ����D  @OrderFood, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:OrderFood	OrderFood  5   	        OrderFood.CustomMessageBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:OrderFood     5   	     � 
ResizeMode$  NoResize=�5   
    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ CustomMessageBox��5   	   $	��200��5   	   $	��350��6   .��5      � ���	#FFABADB3 � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $
��auto �6   .+�5   
   �� ���	#FF484F5B$��0��5      $��3��5       �� CornerRadius$ 10��5      $��3q�5      �� 5   
   ���	#FFABADB3$��1��5      $��3q�5      �� 5   
   -   5         ��Name$ tblTitle��5      $=��7заголовок для кастомного окна��5      $��0��5      
�������$��0,0,0,0q�5       �� Padding$ 12,3,0,0q�5!      �� 5"   
    �� Orientation$ 
Horizontal=�6   $��1��5#      $��3,5,3,10q�5$      .+�5%      �� -   5        	 ��Name$	 imgBox��5%      $��50��5&      $��50��5'      $��	20,0,10,0q�5(      �� 5*      $	��254��6   $	��118��5+      $
��Auto=�5,      .��5-      �� -   5        $ 
tblContent��5-      $��Center=�5.      $5��/текст для кастомного окна��5/      $
��Wrap=�50      51      52      �� 53   
   $ 
Horizontal=�6   $��Right=�54      $��Bottom=�55      $��2��56      $��	0,10,30,0q�57      .+�58      �� -   5        
 ��Name$
 btnNo��58      $��80��59      $��
Назад��5:      $��5,0,5,10q�5;      $��14(�5<         
ExitButton#��[  5=      5>      �� 5?      -   5        $
 btnYes��5?      $��80��5@      $��OK��5A      $��5,0,5,10q�5B      $��14(�5C        
NextButton#��[ 5D      5E      5F      5G      5H      