   M S B A M L   `   `   `  ����E  ASliderDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SliderDemo
SliderDemo  5   	       SliderDemo.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SliderDemo     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �� $��Center=�6   $��20q�6,   .+�5
   
   �� -   5         ��Name$ mySlider��5       � Maximum$	 100Q�5
       �� TickPlacement$ BottomRight=�6    � Minimum$ 10Q�5       �� IsSnapToTickEnabled$
 True��5       � Value$ 50Q�5       �� TickFrequency$ 10Q�5      5      �� 5   
   -   5         ��Name$ myTextBlock��5      ��5      �� 	 �� ElementName$	 mySlider��
 �� Path$
 Value� �� UpdateSourceTrigger$ PropertyChanged=�Hello6v   5      5      