   M S B A M L   `   `   `  ����F  BDatVelib-UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DatVelib_UIDatVelib_UI  5   	       DatVelib_UI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DatVelib_UI     5   	     � Title$  DATVELIB��5   	   $
��2000��6   $��2000         ��6(    � WindowStartupLocation$ CenterScreen=�5	       � WindowState$ 	Maximized=�60   .��5
      � ���	#FF455A64.+�5   
   �� -   5         ��Name$ 
InputPanel��5      $��66,29,1288,10q�6*   $	��638��6A   .+�5      �� -   5         ��Name$ StartBox��5      $��60��6(    �� TextWrapping$
 Wrap=�64   $�� ��6H   $��36(�6P   ���	#FF757575$��Segoe UI Light)�6�   6  �� 5      -   5        $ 	FinishBox��5      $��60��6)   $
 Wrap=�65   $�� ��6I   $��36(�6Q   ���	#FF757575$��Segoe UI Light)�6�   6  �� 5      -   5         ��Name$ GoBlock��5      $
��Wrap=�6)   $��Trouver un trajet��6=   ���	#FF2196F3
�������$��48(�6�   $��Segoe UI Light)�6�   6�   �� 5      -   5        $ 	HelpBlock��5      $
��Wrap=�6+   $;��5Les adresses doivent être sous la forme "Rue Ville".��6?   $��18(�6�   
�������$��0,10,0,0q�6�   �� 5      -   5        $ 
ErrorBlock��5      $
��Wrap=�6,   $U��OErreur : Assurez vous que l'adresse est valide et respecte le format précisé.��6@   ���	#FFFC603E
�������$��18(�6�    �� Padding$ 	5,10,0,10q�6�   $��0,10,0,0q�6�   $y�Hidden=�6�   5      �� 5   
   -   5        $ ResultPanel��5      $
��Left=�6*   $
��1270��6E   $��
977,29,0,0q�6S   $	��Top=�6g   $	��604��6   .+�5      �� -   5        $ ResultTitle��5      $
��Wrap=�6-   $��Votre trajet��6A    �� TextAlignment$ Center=�6U   $��Segoe UI Light)�6l   
����������	#FF2196F3$��30(�6�   �� 5      -	   5        $ TrajectoryBlock��5      $
��Wrap=�61   $��20(�6E   $��Segoe UI Light)�6S   
�������$ 0,10,0,0q�6�   �� 5      $��61��6   $��0q�6$   
�������6/   �� 5      -
   5        	 ��Name$	 Scroller��5      $	��574��6-   .��5      �� -   5        $ InstructionsPanel��5      $	��581��68   5      �� 5      -   5        $ ReturnBlock��5      $
��Wrap=�6-   $��Retour��6A   ���	#FFFC6042
�������$��Segoe UI Light)�6y   $��30(�6�   $ Center=�6�   $
 0,15q�6�   $��0,10,0,0q�6�   6#  5      5      5      