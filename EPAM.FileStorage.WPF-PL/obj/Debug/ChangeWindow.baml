   M S B A M L   `   `   `  ����R  NEPAM.FileStorage.WPF-PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:EPAM.FileStorage.WPF_PLEPAM.FileStorage.WPF_PL  5   	   *    $EPAM.FileStorage.WPF_PL.ChangeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:EPAM.FileStorage.WPF_PL     5   	     � Title$  ChangeWindow��5   	   $��342.509��6   $��669.647��6/    � 
ResizeMode$ NoResize=�6?   .��5	      � .+�5
   
   �� $��Enter current password:��6   $
��Left=�62   $��	33,34,0,0q�6M   $	��Top=�6`   �� 5   
   -   5         ��Name$ CurrentPasswordField��5      $
��Left=�60   $��23��6K   $��
173,37,0,0q�6W    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $	��204��6�   �� 5   
   $����Here you can change profile name, password, or both. 
If you want to change something specific - just input new data in text fields and leave not requiered fields empty��6   $
��Left=�6�   $��	33,65,0,0q�6�   $	��Top=�6�   �� 5   
   $��	New name:��6   $
��Left=�6$   $��
33,112,0,0q�6?   $	��Top=�6S   �� 5   
   $��New password:��6   $
��Left=�6(   $��
33,145,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $ NewNameTextField��5      $
��Left=�6,   $��23��6G   $��173,112,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��204��6�   �� 5   
   -   5        $ NewPasswordTextField��5      $
��Left=�60   $��23��6K   $��173,147,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��204��6�   �� 5   
   -   5         ��Name$ CloseButton��5      $
��Exit��6&   $
��Left=�65   $��302,283,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ ChangeNameButton��5      $��Change��6+   $
��Left=�6<   $��397,113,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ ChangePasswordButton��5      $��Change��6/   $
��Left=�6@   $��397,147,0,0q�6[   $	��Top=�6p   $��75��6�   6�   �� 5   
   $)��#You can delete your profile here ->��6   $
��Left=�6A   $��
33,228,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ DeleteProfileButton��5      $��Delete profile��6.   $
��Left=�6G   $��276,231,0,0q�6b   $	��Top=�6w   $	��127��6�   6�   5      5      