   M S B A M L   `   `   `  ����M  IMedicalInstitution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MedicalInstitution.ViewsMedicalInstitution.Views  5   	   %    MedicalInstitution.Views.Choice   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:MedicalInstitution.Views     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  L-company (Login)��5	   	   $	��150��5
   	   $	��400��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� 
������$	��150��5      $	��400��5      $��3q�5      ._�5   
   �  � RowDefinitions 5      �� 5      $��70 �6    6.   �� 5      6"   .+�5      � $��0��6   .+�5      �� -   5         ��Name$
 Exit��5      $��1��5       0  ,MaterialDesignFloatingActionMiniAccentButton#��[  5       � ToolTip$ Exit App��5      ���	#FFC34A4A���	#FFC34A4A$��22��5       $��22��5!      $��10q�5"      $��Right=�5#      $	��Top=�5$      $y�Visible=�5%      ��5      �� *Exit+ �� UpdateSourceTrigger$ PropertyChanged=�.��5&      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   $��16��5'   .   $��16��5(   .   5)      �� 5*      $��Center=�6   $��Center=�5+      $��30(�5,      
����  �$
��Bold"�5.      	Vi ste?67   5/      � 50      $��1��6   	 � ColumnDefinitions	 51      �� 52      6)   �� 53      $��20 �6'   64   �� 54      6)   .+�56      � $��0��6   .+�57      �� -   5        $ 
btnPatient��57      +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 20��58      $��45��59      $
��Bold"�5:      $	��100��5;      $��50,0,0,0q�5<       �� 	IsDefault . ��5=      �� *	Patient+$ PropertyChanged=�.��5?   6   
Pacijent6@   5@      � 5A      $��1��6   .+�5B      �� 
����  �$��2��62   $��50��6<   6J   5C      � 5D      $��2��6   .+�5E      �� -   5        $ 	btnDoctor��5E      $
 20��5F      $��45��5G      $
��Bold"�5H      $	��100��5I      $��0,0,50,0q�5J       . ��5K      �� *Doctor+$ PropertyChanged=�.��5M   5   Lekar6<   5N      5O      5P      5Q      5R      