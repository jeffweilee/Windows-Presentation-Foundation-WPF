   M S B A M L   `   `   `  ����  CalculatorJeff    CalculatorJeff.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  CalculatorJeff��5   	   $	��367��6    $	��295��6-    � WindowStyle$ 
ToolWindow=�69    � 
ResizeMode$ NoResize=�6R   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5      $ White��6   $ 1Q�6)   5	      .��5      � $��Disabled=�6   $��	0,82,0,-6q�6?    � ColumnDefinitions 5   
   �� 5      $	��92* �6   �� 5      $
��193* �6   �� 5      $��4 �6   .+�5   
   �� -   5         ��Name$ 	answerbar��5      $
��Left=�6'   $��	9,-23,0,0q�6B   $
��Wrap=�6U   $	��Top=�6i   $��60��6�   $	��265��6�   	 �� TextAlignment$	 Right=�6�   
 � Cursor$

 None��6�   $��0��6�   $��48(�6�   $��2��6�   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ 	#FFD4C2C2��6#   $ 1Q�65   � 5      $ 	#FFE0D2D2��6#   5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#   5   "   �� 5   
   -   5         ��Name$
 btn0��5      $��0��6   $
��Left=�6+   $��
10,202,0,0q�6F   $	��Top=�6Z   $��50��6r   $��45��6}   ���	#FFC8C8C86�   �� 5   
   -   5        $
 btn1��5      $��1��6   $
��Left=�6+   $��
10,152,0,0q�6F   $	��Top=�6Z   $��50��6r   $��45��6}   ���	#FFC8C8C86�   �� 5   
   -   5        $
 btn6��5      $��6��6   $
��Left=�6+   $��
10,102,0,0q�6F   $	��Top=�6Z   $��50��6r   $��45��6}   ���	#FFC8C8C86�   �� 5    
   -   5        $
 btn7��5       $��7��6   $
��Left=�6+   $��9,51,0,0q�6F   $	��Top=�6X   $��50��6p   $��45��6{   ���	#FFC8C8C86�   �� 5!   
   -   5        $ btnpoint��5!      $��.��6#   $
��Left=�6/   $��
64,202,0,0q�6J   $	��Top=�6^   $��50��6v   $��45��6�   ���	#FFC8C8C8$��2��6�   �� 5"   
   -   5        $
 btn2��5"      $��2��6   $
��Left=�6+   $��
65,152,0,0q�6F   $	��Top=�6Z   $��50��6r   $��45��6}   ���	#FFC8C8C8$��2��6�   �� 5#   
   -	   5        $
 btn5��5#      $��5��6   $
��Left=�6+   $��
64,101,0,0q�6F   $	��Top=�6Z   $��50��6r   $��45��6}   ���	#FFC8C8C8$��2��6�   �� 5$   
   -
   5        $
 btn8��5$      $��8��6   $
��Left=�6+   $��	64,51,0,0q�6F   $	��Top=�6Y   $��50��6q   $��45��6|   ���	#FFC8C8C8$��2��6�   �� 5%   
   -   5        $ btnnv��5%      $��±��6    $
��Left=�6,   $��
27,202,0,0q�6G   $	��Top=�6[   $��50��6s   $��45��6~   ���	#FFC8C8C8$��1��6�   �� 5&   
   -   5        $
 btn3��5&      $��3��6   $
��Left=�6+   $��
27,152,0,0q�6F   $	��Top=�6Z   $��50��6r   $��45��6}   ���	#FFC8C8C8$��1��6�   �� 5'   
   -   5        $
 btn4��5'      $��4��6   $
��Left=�6+   $��
27,101,0,0q�6F   $	��Top=�6Z   $��50��6r   $��45��6}   ���	#FFC8C8C8$��1��6�   �� 5(   
   -   5        $
 btn9��5(      $��9��6   $
��Left=�6+   $��	27,51,0,0q�6F   $	��Top=�6Y   $��50��6q   $��45��6|   ���	#FFC8C8C8$��1��6�   �� 5)   
   -   5        $ btndiv��5)      $��÷��6!   $
��Left=�6-   $��
79,202,0,0q�6H   $	��Top=�6\   $��50��6t   $��45��6   ���	#FFC8C8C8$��1��6�   �� 5*   
   -   5        $ btnmut��5*      $��×��6!   $
��Left=�6-   $��
79,152,0,0q�6H   $	��Top=�6\   $��50��6t   $��45��6   ���	#FFC8C8C8$��1��6�   �� 5+   
   -   5        $ btncut��5+      $��-��6!   $
��Left=�6-   $��
79,102,0,0q�6H   $	��Top=�6\   $��50��6t   $��45��6   ���	#FFC8C8C8$��1��6�   �� 5,   
   -   5        $ btnadd��5,      $��+��6!   $
��Left=�6-   $��	79,51,0,0q�6H   $	��Top=�6[   $��50��6s   $��45��6~   ���	#FFC8C8C8$��1��6�   �� 5-   
   -   5        $ btnequ��5-      $��=��6!   $
��Left=�6-   $��133,202,0,0q�6H   $	��Top=�6]   $��50��6u   $��45��6�   ���	#FFC8C8C8$��1��6�   �� 5.   
   -   5        $ btnback��5.      $
��← ��6"   $
��Left=�6/   $��133,152,0,0q�6J   $	��Top=�6_   $��50��6w   $��45��6�   ���	#FFC8C8C8$��1��6�   �� 5/   
   -   5        $ btnac��5/      $��AC��6    $
��Left=�6-   $��133,102,0,0q�6H   $	��Top=�6]   $��50��6u   $��45��6�   ���	#FFC8C8C8$��1��6�   �� 50   
   -   5        $ 
btnacancel��50      $��C��6%   $
��Left=�61   $��
133,51,0,0q�6L   $	��Top=�6`   $��50��6x   $��45��6�   ���	#FFC8C8C8$��1��6�   �� 51   
   -   5         ��Name$ me��51      $
��Left=�6   $	��150��68   $��7,-12,-233,0q�6E   $	��Top=�6[   $	��230��6s   $��2��6   ]� 52   
   $��
0,-83,0,24q�6   $��3��6(   .+�53      o� -   5         o�Name$ menu1��53      $	��Top=�6"   ���	#FFFDFCFC���	#FF1B1212.@�54      m� -   5         m�Name$ mufile��54      $��_File(F)��6+   ���	#FFFDFCFC���	#FF1B1212$��58��6m   $��14(�6x   .@�55      m� -   5        $��_Exit(E)��55      ���	#FF75D340���	#FF1B1212$��14(�6`   6n   56      m� 57      -   5        $ muhelp��57      $��	_Help (H)��6+   ���	#FFFDFCFC���	#FF1B1212$��75��6m   $��14(�6x    J� OpacityMask
 �   �.@�58      m� -   5        $��_AboutMe��58      ���	#FF75D340���	#FF1B12126`   59      5:      �� 5<      $��	0,3,0,-19q�6   .+�5=      �� -   5        $ showbar��5=      $
��Wrap=�6-   $��23��6A   $	 Right=�6M   
�������$	��254��6v   $��16(�6�   �� 6�    � Language$ zh-tw�6�   $�0��6�   6�   5>      5?      5@      5A      