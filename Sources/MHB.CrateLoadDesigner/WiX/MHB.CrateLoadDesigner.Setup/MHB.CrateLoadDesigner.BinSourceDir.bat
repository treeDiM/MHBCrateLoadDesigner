del /q "..\..\MHB.CrateLoadDesigner.Desktop\bin\Release\*.pdb"
del /q "..\..\MHB.CrateLoadDesigner.Desktop\bin\Release\*.dll.config"
del /q "..\..\MHB.CrateLoadDesigner.Desktop\bin\Release\*.xml"
del /q "..\..\MHB.CrateLoadDesigner.Desktop\bin\Release\*.resx"

"C:\Program Files (x86)\WiX Toolset v3.14\bin\heat.exe" dir "..\..\MHB.CrateLoadDesigner.Desktop\bin\Release" -dr Bin -cg CompGroup_MHB_CrateLoadDesigner -gg -g1 -sf -srd -sreg -var "var.MHBCrateLoadDesignerBinSourceDir" -o ".\GroupCrateLoadDesigner.wxs"