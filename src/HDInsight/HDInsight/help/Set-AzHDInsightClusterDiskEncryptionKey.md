---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version:
schema: 2.0.0
---

# Set-AzHDInsightClusterDiskEncryptionKey

## SYNOPSIS
Rotate the disk encryption key of the specified HDInsight cluster.

## SYNTAX

```
Set-AzHDInsightClusterDiskEncryptionKey [-EncryptionKeyName] <String> [-EncryptionKeyVersion] <String>
 [-EncryptionVaultUri] <String> [-ClusterName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Rotate the disk encryption key of the specified HDInsight cluster. For this operation, the cluster must have access to both the current key and the intended new key, otherwise the rotate key operation will fail.

## EXAMPLES

### Example 1
```powershell
PS C:\> # Cluster configuration info
        $clusterResourceGroupName = "Group"
        $clusterName = "your-cmk-cluster"

Set-AzHDInsightClusterDiskEncryptionKey `
		-ResourceGroupName $clusterResourceGroupName `
		-ClusterName $clusterName `
		-EncryptionKeyName new-key `
		-EncryptionVaultUri https://MyKeyVault.vault.azure.net `
		-EncryptionKeyVersion 00000000000000000000000000000000
```

## PARAMETERS

### -ClusterName
Gets or sets the name of the cluster.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKeyName
Gets or sets the encryption key name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKeyVersion
Gets or sets the encryption key version.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionVaultUri
Gets or sets the encryption vault uri.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Gets or sets the name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.HDInsight.Models.Cluster

## NOTES

## RELATED LINKS
[Customer-managed key disk encryption](https://docs.microsoft.com/en-us/azure/hdinsight/disk-encryption)
