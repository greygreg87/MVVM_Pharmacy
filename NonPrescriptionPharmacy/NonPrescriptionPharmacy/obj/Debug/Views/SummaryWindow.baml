   M S B A M L   `   `   `  ����R  NNonPrescriptionPharmacy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:NonPrescriptionPharmacyNonPrescriptionPharmacy  5   	   W0clr-namespace:NonPrescriptionPharmacy.ViewModels"NonPrescriptionPharmacy.ViewModels  5   	   1    +NonPrescriptionPharmacy.Views.SummaryWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:NonPrescriptionPharmacy     5   	   G
viewModels0clr-namespace:NonPrescriptionPharmacy.ViewModels     5   	   ���#777777  � Title$  SummaryWindow��5
   	   $	��300��6   $	��360��6,    � 
ResizeMode$ NoResize=�68    � 	Resources 5      4  .NonPrescriptionPharmacy.NumberToPriceConverter   priceConverter/  )NonPrescriptionPharmacy.ToAmountConverter  amountConverter��%:   &	        &	        5   
   6'     5   
   6"   5      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��5* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   ��   Headers#��[ 6   $��0��61   $��0��6>   $��2��6N   $��Twoje zamówienie:��6b   $��18(�6~   $��Center=�6�   $��Center=�6�   �� 5   
   $��1��6J   $��0��6W   $��2��6g   $��3q�6|   ��6   �� *SummaryMedicament+ �� Mode$ TwoWay=���5      �� 5      .R�5      �� ._�5       �  5!      �� 5"   "   $	��150 �63   �� 5#   "   $��50 �63   �� 5$   "   $��99 �63   .+�5&      �� $��0��6J   $
��Left=�6Z   ��6$   �� *Name+$ TwoWay=�6Z   �� 5'      $��1��6x   $��Center=�6�   ��6$   �� *Amount+$ TwoWay=� �� 	Converter# [ 6�   �� 5(      $��2��6{   $��Right=�6�   ��6$   �� *
TotalPrice+$ TwoWay=�# [  6�   5)      5*      5+      5-      �� 5.   
   $��2��6   $��0��6   $��Do zapłaty:��6-   $��Center=�6C   �� 5/   
   $��2��6   $��1��6   {�.  $��Center=�6�   $��Center=�6�   $��90��6�   ��6/   �� *SummaryCost+# [  6�   �� 50   
   $��3��6   $��0��6   $*��$Czy to wszystko? Jeśli nie kliknij:��6-   $��Center=�6[   $��Center=�6v   �� 51   
   $��3��63   $��1��6@   $��Powrót��6P   $��3q�6a   ��6   �� *CancelCommand+6a   �� 52   
   $��4��6   $��0��6   $"��Aby przejść dalej kliknij:��6-   $��Center=�6R   $��Center=�6m   �� 53   
   $��4��60   $��1��6=   $��Zapłać��6M   $��3q�6^   ��6   �� *
PayCommand+6^   55      56      