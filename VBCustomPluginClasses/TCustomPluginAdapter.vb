'Imports stdole
'Imports System.IO
'Imports System.Net
'Imports System.Text
'Imports System.Windows
'Imports System.Windows.Forms
'Imports System.Windows.Controls
'Imports System.Security.Principal
'Imports System.Management
'Imports System.Reflection
'Imports MSXML
'Imports RetailPro.Plugins

'' *** Disclaimer ***
''
'' THIS SOFTWARE IS PROVIDED "AS IS" AND ANY EXPRESSED OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
'' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
'' SHALL THE REGENTS OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
'' CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; 
'' LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
'' WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT 
'' OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
''

'Public Class TCustomPluginAdapter
'    Implements IPluginAdapter

'#Region "IPluginAdapter Members"

'#Region "CheckForErrors"

'    Private fLogName As String = "PluginAdapterExceptions"

'    Public Property LogName() As String
'        Get
'            Return fLogName
'        End Get
'        Set(value As String)
'            fLogName = value
'        End Set
'    End Property
'    ' Todo: add an array of parameters and values so they can be logged when an exception is thrown

'    Private Function PluginErrorMsg() As String
'        Dim PluginError As String = Convert.ToString((Convert.ToString("[" + LastErrorCode.ToString() + "] ") & LastErrorFunction) + ": ") & LastErrorMessage

'        Return If(PluginError = "", "UNKNOWN PluginException", PluginError)
'    End Function  'PluginErrorMsg

'    Public Overridable Sub CheckForErrors()
'        ' Because ltError ALWAYS is logged no matter the TLogLevel and we are only logging Exceptions
'        ' in TCustomPluginAdapter, the LogLevel is unimportant here.
'        ' TLogLevel.logNone;
'        If LastErrorCode <> CInt(PluginError.peSuccess) Then
'            Logger.Instance.FileName = LogName
'            Logger.Instance.Log(PluginErrorMsg(), TLogType.ltError, TLogLevel.logALL)

'            Throw New PluginException(PluginErrorMsg())
'        End If
'    End Sub  'CheckForErrors

'    Public Overridable Sub CheckForErrors(AResponse As Integer)
'        ' tests that a method is not out of sysnc with LastErrorCode
'        If AResponse <> LastErrorCode Then
'            If (AResponse <> CInt(PluginError.peSuccess)) OrElse (LastErrorCode <> CInt(PluginError.peSuccess)) Then
'                Logger.Instance.FileName = "PIAPI_Exception"
'                Logger.Instance.Log(PluginErrorMsg(), TLogType.ltError, TLogLevel.logALL)
'                Logger.Instance.Log((Convert.ToString(" The Method '") & LastErrorFunction) + "'", TLogType.ltError, TLogLevel.logALL)
'                Logger.Instance.Log(" Response      = [" + AResponse + "]", TLogType.ltError, TLogLevel.logALL)
'                Logger.Instance.Log(" LastErrorCode = [" + LastErrorCode + "]", TLogType.ltError, TLogLevel.logALL)
'                Logger.Instance.Log(" ************************************* ", TLogType.ltError, TLogLevel.logALL)
'                Logger.Instance.Log(" This may be a bug, please report ASAP. ", TLogType.ltError, TLogLevel.logALL)
'                Logger.Instance.Log(" ************************************* ", TLogType.ltError, TLogLevel.logALL)
'            End If
'        End If
'        CheckForErrors()
'    End Sub  'CheckForErrors

'#End Region  'CheckForErrors

'    'Dim fAdapter as IPluginAdapter
'    Private Shared adapter As TCustomPluginAdapter
'    '= new TCustomPluginAdapter()

'    Private Sub New()
'    End Sub

'    Public Shared ReadOnly Property fAdapter() As TCustomPluginAdapter
'        Get
'            If adapter Is Nothing Then
'                adapter = New TCustomPluginAdapter()
'            End If
'            Return adapter
'        End Get
'    End Property
'    'Set
'    '    MessageBox.Show("Setting Adapter")
'    '    fadapter = ( value as IPluginAdapter)
'    'End Set

'    Public Sub APIVersion(ByRef MajorVersion As Integer, ByRef MinorVersion As Integer, ByRef Revision As Integer)
'        APIVersion(MajorVersion, MinorVersion, Revision)
'        CheckForErrors()
'    End Sub

'    Public ReadOnly Property AllBONames() As Object
'        Get
'            Dim response As Object
'            response = AllBONames
'            CheckForErrors()
'            Return response
'        End Get
'    End Property

'    Public Function BOCanBeCreated(BOHandle As Integer) As Boolean
'        Dim response As Boolean
'        response = BOCanBeCreated(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOCancel(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOCancel(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOClear(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOClear(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOClearActiveFakeValues(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOClearActiveFakeValues(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOClearInstanceIncluded(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOClearInstanceIncluded(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOClearListIncluded(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOClearListIncluded(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOClearTempClosingState(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOClearTempClosingState(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOClose(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOClose(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOCloseStandalone(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOCloseStandalone(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOCopy(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOCopy(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BODelete(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BODelete(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BODisableAccessSecurity(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BODisableAccessSecurity(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BODisableDataSetControls(BOHandle As Integer, ASkipIfEdit As Boolean) As Integer
'        Dim response As Integer
'        response = BODisableDataSetControls(BOHandle, ASkipIfEdit)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BODisableLayoutNotifier(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BODisableLayoutNotifier(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BODisableSecurity(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BODisableSecurity(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOEdit(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOEdit(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOEnableAccessSecurity(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOEnableAccessSecurity(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOEnableDataSetControls(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOEnableDataSetControls(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOEnableLayoutNotifier(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOEnableLayoutNotifier(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOEnableSecurity(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOEnableSecurity(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOExecuteMethod(BOHandle As Integer, AMethodName As String, AParameterNames As Object, AParameterValues As Object) As Object
'        Dim response As Object
'        response = BOExecuteMethod(BOHandle, AMethodName, AParameterNames, AParameterValues)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOF(BOHandle As Integer) As Boolean
'        Dim response As Boolean
'        response = BOF(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOFirst(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOFirst(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOFocusAttr(BOHandle As Integer, AAttributeName As String) As Integer
'        Dim response As Integer
'        response = BOFocusAttr(BOHandle, AAttributeName)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOGetActive(BOHandle As Integer) As Boolean
'        Dim response As Boolean
'        response = BOGetActive(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetActiveDataSetId(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOGetActiveDataSetId(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOGetAttrPropVal(BOHandle As Integer, AAttributeName As String, APropertyID As Integer) As Object
'        Dim response As Object
'        response = BOGetAttrPropVal(BOHandle, AAttributeName, APropertyID)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetAttrPropValues(BOHandle As Integer, AAttributeName As String, APropertyIDs As Object) As Object
'        Dim response As Object
'        response = BOGetAttrPropValues(BOHandle, AAttributeName, APropertyIDs)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetAttributeNameList(BOHandle As Integer) As Object
'        Dim response As Object
'        response = BOGetAttributeNameList(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetAttributePermissions(BOHandle As Integer, AttrName As String, APermission As Integer, ACached As Boolean, AOvrCache As Boolean) As Boolean
'        Dim response As Boolean
'        response = BOGetAttributePermissions(BOHandle, AttrName, APermission, ACached, AOvrCache)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetAttributeValueByName(BOHandle As Integer, AttrName As String) As Object
'        Dim response As Object
'        response = BOGetAttributeValueByName(BOHandle, AttrName)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetAttributeValues(BOHandle As Integer, AAttributeNames As Object) As Object
'        Dim response As Object
'        response = BOGetAttributeValues(BOHandle, AAttributeNames)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetCommitOnPost(BOHandle As Integer) As Boolean
'        Dim response As Boolean
'        response = BOGetCommitOnPost(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetCopyUniqueId(BOHandle As Integer) As Object
'        Dim response As Object
'        response = BOGetCopyUniqueId(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetInstanceActive(BOHandle As Integer) As Boolean
'        Dim response As Boolean
'        response = BOGetInstanceActive(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetModified(BOHandle As Integer) As Boolean
'        Dim response As Boolean
'        response = BOGetModified(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetPosition(BOHandle As Integer, ByRef APosition As Object) As Integer
'        Dim response As Integer
'        response = BOGetPosition(BOHandle, APosition)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetPref(BOHandle As Integer, APref As Integer) As Object
'        Dim response As Object
'        response = BOGetPref(BOHandle, APref)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetPropValById(BOHandle As Integer, AId As Integer) As Object
'        Dim response As Object
'        response = BOGetPropValById(BOHandle, AId)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetReadOnly(BOHandle As Integer) As Boolean
'        Dim response As Boolean
'        response = BOGetReadOnly(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOGetRepEntityId(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOGetRepEntityId(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOGetState(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOGetState(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOGetUniqueId(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOGetUniqueId(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOIncludeAttrForced(BOHandle As Integer, AAttributeName As String, AInclude As Boolean) As Integer
'        Dim response As Integer
'        response = BOIncludeAttrForced(BOHandle, AAttributeName, AInclude)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOIncludeAttrIntoInstance(BOHandle As Integer, AAttributeName As String, AInclude As Boolean, AForce As Boolean) As Integer
'        Dim response As Integer
'        response = BOIncludeAttrIntoInstance(BOHandle, AAttributeName, AInclude, AForce)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOIncludeAttrIntoList(BOHandle As Integer, AAttributeName As String, AInclude As Boolean, AForce As Boolean) As Integer
'        Dim response As Integer
'        response = BOIncludeAttrIntoList(BOHandle, AAttributeName, AInclude, AForce)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOInsert(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOInsert(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOIsAttributeInInstance(BOHandle As Integer, AAttributeName As String) As Boolean
'        Dim response As Boolean
'        response = BOIsAttributeInInstance(BOHandle, AAttributeName)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOIsAttributeInList(BOHandle As Integer, AAttributeName As String) As Boolean
'        Dim response As Boolean
'        response = BOIsAttributeInList(BOHandle, AAttributeName)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOIsEmpty(BOHandle As Integer) As Boolean
'        Dim response As Boolean
'        response = BOIsEmpty(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOIsEntity(BOHandle As Integer, AEntityId As Integer) As Boolean
'        Dim response As Boolean
'        response = BOIsEntity(BOHandle, AEntityId)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOIsEntityArray(BOHandle As Integer, AEntityIds As Object) As Boolean
'        Dim response As Boolean
'        response = BOIsEntityArray(BOHandle, AEntityIds)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOLast(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOLast(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOLocateByAttributes(BOHandle As Integer, AAttributeNames As Object, AAttributeValues As Object) As Integer
'        Dim response As Integer
'        response = BOLocateByAttributes(BOHandle, AAttributeNames, AAttributeValues)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOLocatePosition(BOHandle As Integer, APosition As Object) As Boolean
'        Dim response As Boolean
'        response = BOLocatePosition(BOHandle, APosition)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BONext(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BONext(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOOpen(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOOpen(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOPost(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOPost(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOPostAllDataSets(BOHandle As Integer, PostCollections As Boolean) As Integer
'        Dim response As Integer
'        response = BOPostAllDataSets(BOHandle, PostCollections)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOPostEx(BOHandle As Integer, ACancelOnError As Boolean) As Integer
'        Dim response As Integer
'        response = BOPostEx(BOHandle, ACancelOnError)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOPrint(BOHandle As Integer, ADocDesignName As String, AOverridePrinterName As String) As Integer
'        Dim response As Integer
'        response = BOPrint(BOHandle, ADocDesignName, AOverridePrinterName)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOPrior(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOPrior(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BORecalculateAttribute(BOHandle As Integer, AAttributeName As String) As Integer
'        Dim response As Integer
'        response = BORecalculateAttribute(BOHandle, AAttributeName)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BORefresh(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BORefresh(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BORefreshRecord(BOHandle As Integer, AForce As Boolean, ARefreshCollection As Boolean) As Integer
'        Dim response As Integer
'        response = BORefreshRecord(BOHandle, AForce, ARefreshCollection)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BORollBack(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BORollBack(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSetActive(BOHandle As Integer, B As Boolean) As Integer
'        Dim response As Integer
'        response = BOSetActive(BOHandle, B)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSetAttributeValueByName(BOHandle As Integer, AttrName As String, AValue As Object) As Integer
'        Dim response As Integer
'        response = BOSetAttributeValueByName(BOHandle, AttrName, AValue)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSetAttributeValues(BOHandle As Integer, AAttributeNames As Object, AValue As Object) As Integer
'        Dim response As Integer
'        response = BOSetAttributeValues(BOHandle, AAttributeNames, AValue)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSetCommitOnPost(BOHandle As Integer, B As Boolean) As Integer
'        Dim response As Integer
'        response = BOSetCommitOnPost(BOHandle, B)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSetFilter(BOHandle As Integer, ADomain As Integer, AValue As Object, AOperation As Integer, AFilterData As Boolean, AFilterLookup As Boolean) As Integer
'        Dim response As Integer
'        response = BOSetFilter(BOHandle, ADomain, AValue, AOperation, AFilterData, AFilterLookup)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSetFilterAttr(BOHandle As Integer, AAttributeName As String, AValue As Object, AOperation As Integer, AFilterData As Boolean, AFilterLookup As Boolean) As Integer
'        Dim response As Integer
'        response = BOSetFilterAttr(BOHandle, AAttributeName, AValue, AOperation, AFilterData, AFilterLookup)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSetReadOnly(BOHandle As Integer, B As Boolean) As Integer
'        Dim response As Integer
'        response = BOSetReadOnly(BOHandle, B)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSetTempClosingState(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOSetTempClosingState(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSortByAttribute(BOHandle As Integer, AAttributeName As String, ASortOrder As Integer, AReopen As Boolean) As Integer
'        Dim response As Integer
'        response = BOSortByAttribute(BOHandle, AAttributeName, ASortOrder, AReopen)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOSortByDomain(BOHandle As Integer, ADomain As Integer, ASortOrder As Integer, AReopen As Boolean) As Integer
'        Dim response As Integer
'        response = BOSortByDomain(BOHandle, ADomain, ASortOrder, AReopen)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOUpdateActiveInstance(BOHandle As Integer, AForce As Boolean) As Integer
'        Dim response As Integer
'        response = BOUpdateActiveInstance(BOHandle, AForce)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOUpdateDataSetRecords(BOHandle As Integer, IncludeRefs As Boolean) As Integer
'        Dim response As Integer
'        response = BOUpdateDataSetRecords(BOHandle, IncludeRefs)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOUpdateInstanceCollections(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOUpdateInstanceCollections(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOUpdateInstanceDataSet(BOHandle As Integer, AForceRefresh As Boolean, AForceDataSetCreation As Boolean) As Boolean
'        Dim response As Boolean
'        response = BOUpdateInstanceDataSet(BOHandle, AForceRefresh, AForceDataSetCreation)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function BOUpdateListCollections(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = BOUpdateListCollections(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function BOUpdateListDataSet(BOHandle As Integer, AForceRefresh As Boolean, AForceDataSetCreation As Boolean) As Boolean
'        Dim response As Boolean
'        response = BOUpdateListDataSet(BOHandle, AForceRefresh, AForceDataSetCreation)
'        CheckForErrors()
'        Return response
'    End Function

'    Public ReadOnly Property ChildBOList() As Object
'        Get
'            Dim response As Object
'            response = ChildBOList
'            CheckForErrors()
'            Return response
'        End Get
'    End Property

'    Public Sub ClearLastError()
'        ClearLastError()
'        CheckForErrors()
'    End Sub

'    Public Function CloneBOHandle(SrcBOHandle As Integer, SrcAdapter As IPluginAdapter) As Integer
'        Dim response As Integer
'        response = CloneBOHandle(SrcBOHandle, SrcAdapter)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function Connect(RoleName As String, Username As String, Password As String) As Boolean
'        Dim rstat As Boolean
'        rstat = Connect(RoleName, Username, Password)
'        CheckForErrors()
'        Return rstat
'    End Function

'    Public Function CreateBOByID(BOID As Integer) As Integer
'        Dim response As Integer
'        response = CreateBOByID(BOID)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function CreateBOByName(BOName As String) As Integer
'        Dim response As Integer
'        response = CreateBOByName(BOName)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public ReadOnly Property CurrentEmplId() As String
'        Get
'            Dim response As String
'            response = CurrentEmplId
'            CheckForErrors()
'            Return response
'        End Get
'    End Property

'    Public ReadOnly Property CurrentUserId() As String
'        Get
'            Dim response As String
'            response = CurrentUserId
'            CheckForErrors()
'            Return response
'        End Get
'    End Property

'    Public Function DSCommit() As Integer
'        Dim response As Integer
'        response = DSCommit()
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function DSCreateDataset(ADatasetName As String, AVendorSid As String, ACMSObject As String) As String
'        Dim response As String
'        response = DSCreateDataset(ADatasetName, AVendorSid, ACMSObject)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function DSCreateVendor(AVendorName As String) As String
'        Dim response As String
'        response = DSCreateVendor(AVendorName)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Sub DSDeleteDatasetData(ADatasetSid As String)
'        DSDeleteDatasetData(ADatasetSid)
'        CheckForErrors()
'    End Sub

'    Public Sub DSDeleteIndex(ADatasetSid As String, ARecSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String, ACMSRefKey1 As String, _
'        ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String)
'        DSDeleteIndex(ADatasetSid, ARecSid, ALookupKey1, ALookupKey2, ALookupKey3, ACMSRefKey1, _
'            ACMSRefKey2, ACMSRefKey3, ACMSRefKey4, ACMSRefKey5)
'        CheckForErrors()
'    End Sub

'    Public Sub DSDeleteRecord(ADataRecordSid As String)
'        DSDeleteRecord(ADataRecordSid)
'        CheckForErrors()
'    End Sub

'    Public Sub DSDropDataset(ADatasetSid As String, ACascade As Boolean)
'        DSDropDataset(ADatasetSid, ACascade)
'        CheckForErrors()
'    End Sub

'    Public Sub DSDropVendor(AVendorSid As String)
'        DSDropVendor(AVendorSid)
'        CheckForErrors()
'    End Sub

'    Public Function DSGetDatasetSid(AVendorSid As String, ADatasetName As String) As String
'        Dim response As String
'        response = DSGetDatasetSid(AVendorSid, ADatasetName)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function DSGetRecordByCMSReference(ADatasetSid As String, ACMSRefKey1 As String, ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String, _
'        ByRef ResultSet As Object) As Integer
'        Dim response As Integer
'        response = DSGetRecordByCMSReference(ADatasetSid, ACMSRefKey1, ACMSRefKey2, ACMSRefKey3, ACMSRefKey4, ACMSRefKey5, _
'            ResultSet)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function DSGetRecordByLookup(ADatasetSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String, ByRef ResultSet As Object) As Integer
'        Dim response As Integer
'        response = DSGetRecordByLookup(ADatasetSid, ALookupKey1, ALookupKey2, ALookupKey3, ResultSet)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function DSGetRecordBySid(ADataRecordSid As String, ByRef ResultSet As Object) As Integer
'        Dim response As Integer
'        response = DSGetRecordBySid(ADataRecordSid, ResultSet)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function DSGetRecordSidByCMSReference(ADatasetSid As String, ACMSRefKey1 As String, ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String) As String
'        Dim response As String
'        response = DSGetRecordSidByCMSReference(ADatasetSid, ACMSRefKey1, ACMSRefKey2, ACMSRefKey3, ACMSRefKey4, ACMSRefKey5)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function DSGetRecordSidByLookup(ADatasetSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String) As String
'        Dim response As String
'        response = DSGetRecordSidByLookup(ADatasetSid, ALookupKey1, ALookupKey2, ALookupKey3)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function DSGetVendorSID(AVendorName As String) As String
'        Dim response As String
'        response = DSGetVendorSID(AVendorName)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function DSInsertIndex(ADatasetSid As String, ARecordSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String, ACMSRefKey1 As String, _
'        ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String) As String
'        Dim response As String
'        response = DSInsertIndex(ADatasetSid, ARecordSid, ALookupKey1, ALookupKey2, ALookupKey3, ACMSRefKey1, _
'            ACMSRefKey2, ACMSRefKey3, ACMSRefKey4, ACMSRefKey5)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function DSInsertRecord(ADatasetSid As String, ARecordValue As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String, ACMSRefKey1 As String, _
'        ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String) As String
'        Dim response As String
'        response = DSInsertRecord(ADatasetSid, ARecordValue, ALookupKey1, ALookupKey2, ALookupKey3, ACMSRefKey1, _
'            ACMSRefKey2, ACMSRefKey3, ACMSRefKey4, ACMSRefKey5)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Sub DSModifyDataset(ADatasetSid As String, ANewDatasetName As String, ANewCMSObject As String)
'        DSModifyDataset(ADatasetSid, ANewDatasetName, ANewCMSObject)
'        CheckForErrors()
'    End Sub

'    Public Sub DSModifyIndexLookup(ADataRecordSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String)
'        DSModifyIndexLookup(ADataRecordSid, ALookupKey1, ALookupKey2, ALookupKey3)
'        CheckForErrors()
'    End Sub

'    Public Sub DSModifyIndexReference(ADataRecordSid As String, ACMSRefKey1 As String, ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String)
'        DSModifyIndexReference(ADataRecordSid, ACMSRefKey1, ACMSRefKey2, ACMSRefKey3, ACMSRefKey4, ACMSRefKey5)
'        CheckForErrors()
'    End Sub

'    Public Sub DSModifyVendor(AVendorSid As String, ANewName As String)
'        DSModifyVendor(AVendorSid, ANewName)
'        CheckForErrors()
'    End Sub

'    Public Sub DSUpdateRecord(ADataRecordSid As String, ANewValue As String)
'        DSUpdateRecord(ADataRecordSid, ANewValue)
'        CheckForErrors()
'    End Sub

'    Public Function Disconnect() As Integer
'        Dim response As Integer
'        response = Disconnect()
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function EOF(BOHandle As Integer) As Boolean
'        Dim response As Boolean
'        response = EOF(BOHandle)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Property Enabled() As Boolean
'        Get
'            Throw New NotImplementedException()
'        End Get
'        Set(value As Boolean)
'            Throw New NotImplementedException()
'        End Set
'    End Property

'    Public Function ExecSQL(SQL As String, ByRef ResultSet As Object) As Integer
'        Dim response As Integer
'        response = ExecSQL(SQL, ResultSet)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function GetBOEntityProperties(ABOType As Integer) As String
'        Dim response As String
'        response = GetBOEntityProperties(ABOType)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function GetBOTypeForEntityID(AEntityId As Integer) As Integer
'        Dim response As Integer
'        response = GetBOTypeForEntityID(AEntityId)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function GetHandleForRootBO(BOHandle As Integer) As Integer
'        Dim response As Integer
'        response = GetHandleForRootBO(BOHandle)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function GetReferenceBOForAttribute(BOHandle As Integer, AAttributeName As String) As Integer
'        Dim response As Integer
'        response = GetReferenceBOForAttribute(BOHandle, AAttributeName)
'        CheckForErrors(response)
'        Return response
'    End Function

'    Public Function GetSecurityPermission(AApplicationID As Integer, APermissionID As Integer) As Boolean
'        Dim response As Boolean
'        response = GetSecurityPermission(AApplicationID, APermissionID)
'        CheckForErrors()
'        Return response
'    End Function

'    Public ReadOnly Property LanguageCodePage() As Integer
'        Get
'            Dim response As Integer
'            response = LanguageCodePage
'            CheckForErrors()
'            Return response
'        End Get
'    End Property

'    Public ReadOnly Property LanguageName() As String
'        Get
'            Dim response As String
'            response = LanguageName
'            CheckForErrors()
'            Return response
'        End Get
'    End Property

'    Public ReadOnly Property LastErrorCode() As Integer
'        Get
'            'string response;
'            'CheckForErrors();
'            'return response;
'            Return LastErrorCode
'        End Get
'    End Property

'    Public ReadOnly Property LastErrorFunction() As String
'        Get
'            Return LastErrorFunction
'        End Get
'    End Property

'    Public ReadOnly Property LastErrorMessage() As String
'        Get
'            Return LastErrorMessage
'        End Get
'    End Property

'    Public Sub LogEvent(ALogEventType As Integer, AAreaName As String, AVerbosity As Integer, AMessage As String)
'        LogEvent(ALogEventType, AAreaName, AVerbosity, AMessage)
'        CheckForErrors()
'    End Sub

'    Public Function Rediscover(AFlags As Integer) As Integer
'        Dim response As Integer
'        response = Rediscover(AFlags)
'        CheckForErrors(response)
'        'throw new NotImplementedException();
'        Return response
'    End Function

'    Public ReadOnly Property Reference() As Integer
'        Get
'            Throw New NotImplementedException()
'        End Get
'    End Property

'    Public Function SbsGetPref(ASbs As Integer, APref As Integer) As Object
'        Dim response As Object
'        response = SbsGetPref(ASbs, APref)
'        CheckForErrors()
'        Return response
'    End Function

'    Public Function UpdatePreferences(Preference As MSXML.IXMLDOMElement) As Integer
'        Dim response As Integer
'        response = UpdatePreferences(Preference)
'        CheckForErrors(response)
'        Return response
'    End Function

'#End Region  'IPluginAdapter Members

'    Public ReadOnly Property AllBONames1 As Object Implements IPluginAdapter.AllBONames
'        Get

'        End Get
'    End Property

'    Public Sub APIVersion1(ByRef MajorVersion As Integer, ByRef MinorVersion As Integer, ByRef Revision As Integer) Implements IPluginAdapter.APIVersion

'    End Sub

'    Public Function BOCanBeCreated1(BOHandle As Integer) As Boolean Implements IPluginAdapter.BOCanBeCreated

'    End Function

'    Public Function BOCancel1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOCancel

'    End Function

'    Public Function BOClear1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOClear

'    End Function

'    Public Function BOClearActiveFakeValues1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOClearActiveFakeValues

'    End Function

'    Public Function BOClearInstanceIncluded1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOClearInstanceIncluded

'    End Function

'    Public Function BOClearListIncluded1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOClearListIncluded

'    End Function

'    Public Function BOClearTempClosingState1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOClearTempClosingState

'    End Function

'    Public Function BOClose1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOClose

'    End Function

'    Public Function BOCloseStandalone1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOCloseStandalone

'    End Function

'    Public Function BOCopy1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOCopy

'    End Function

'    Public Function BODelete1(BOHandle As Integer) As Integer Implements IPluginAdapter.BODelete

'    End Function

'    Public Function BODisableAccessSecurity1(BOHandle As Integer) As Integer Implements IPluginAdapter.BODisableAccessSecurity

'    End Function

'    Public Function BODisableDataSetControls1(BOHandle As Integer, ASkipIfEdit As Boolean) As Integer Implements IPluginAdapter.BODisableDataSetControls

'    End Function

'    Public Function BODisableLayoutNotifier1(BOHandle As Integer) As Integer Implements IPluginAdapter.BODisableLayoutNotifier

'    End Function

'    Public Function BODisableSecurity1(BOHandle As Integer) As Integer Implements IPluginAdapter.BODisableSecurity

'    End Function

'    Public Function BOEdit1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOEdit

'    End Function

'    Public Function BOEnableAccessSecurity1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOEnableAccessSecurity

'    End Function

'    Public Function BOEnableDataSetControls1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOEnableDataSetControls

'    End Function

'    Public Function BOEnableLayoutNotifier1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOEnableLayoutNotifier

'    End Function

'    Public Function BOEnableSecurity1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOEnableSecurity

'    End Function

'    Public Function BOExecuteMethod1(BOHandle As Integer, AMethodName As String, AParameterNames As Object, AParameterValues As Object) As Object Implements IPluginAdapter.BOExecuteMethod

'    End Function

'    Public Function BOF1(BOHandle As Integer) As Boolean Implements IPluginAdapter.BOF

'    End Function

'    Public Function BOFirst1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOFirst

'    End Function

'    Public Function BOFocusAttr1(BOHandle As Integer, AAttributeName As String) As Integer Implements IPluginAdapter.BOFocusAttr

'    End Function

'    Public Function BOGetActive1(BOHandle As Integer) As Boolean Implements IPluginAdapter.BOGetActive

'    End Function

'    Public Function BOGetActiveDataSetId1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOGetActiveDataSetId

'    End Function

'    Public Function BOGetAttributeNameList1(BOHandle As Integer) As Object Implements IPluginAdapter.BOGetAttributeNameList

'    End Function

'    Public Function BOGetAttributePermissions1(BOHandle As Integer, AttrName As String, APermission As Integer, ACached As Boolean, AOvrCache As Boolean) As Boolean Implements IPluginAdapter.BOGetAttributePermissions

'    End Function

'    Public Function BOGetAttributeValueByName1(BOHandle As Integer, AttrName As String) As Object Implements IPluginAdapter.BOGetAttributeValueByName

'    End Function

'    Public Function BOGetAttributeValues1(BOHandle As Integer, AAttributeNames As Object) As Object Implements IPluginAdapter.BOGetAttributeValues

'    End Function

'    Public Function BOGetAttrPropVal1(BOHandle As Integer, AAttributeName As String, APropertyID As Integer) As Object Implements IPluginAdapter.BOGetAttrPropVal

'    End Function

'    Public Function BOGetAttrPropValues1(BOHandle As Integer, AAttributeName As String, APropertyIDs As Object) As Object Implements IPluginAdapter.BOGetAttrPropValues

'    End Function

'    Public Function BOGetCommitOnPost1(BOHandle As Integer) As Boolean Implements IPluginAdapter.BOGetCommitOnPost

'    End Function

'    Public Function BOGetCopyUniqueId1(BOHandle As Integer) As Object Implements IPluginAdapter.BOGetCopyUniqueId

'    End Function

'    Public Function BOGetInstanceActive1(BOHandle As Integer) As Boolean Implements IPluginAdapter.BOGetInstanceActive

'    End Function

'    Public Function BOGetModified1(BOHandle As Integer) As Boolean Implements IPluginAdapter.BOGetModified

'    End Function

'    Public Function BOGetPosition1(BOHandle As Integer, ByRef APosition As Object) As Integer Implements IPluginAdapter.BOGetPosition

'    End Function

'    Public Function BOGetPref1(BOHandle As Integer, APref As Integer) As Object Implements IPluginAdapter.BOGetPref

'    End Function

'    Public Function BOGetPropValById1(BOHandle As Integer, AId As Integer) As Object Implements IPluginAdapter.BOGetPropValById

'    End Function

'    Public Function BOGetReadOnly1(BOHandle As Integer) As Boolean Implements IPluginAdapter.BOGetReadOnly

'    End Function

'    Public Function BOGetRepEntityId1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOGetRepEntityId

'    End Function

'    Public Function BOGetState1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOGetState

'    End Function

'    Public Function BOGetUniqueId1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOGetUniqueId

'    End Function

'    Public Function BOIncludeAttrForced1(BOHandle As Integer, AAttributeName As String, AInclude As Boolean) As Integer Implements IPluginAdapter.BOIncludeAttrForced

'    End Function

'    Public Function BOIncludeAttrIntoInstance1(BOHandle As Integer, AAttributeName As String, AInclude As Boolean, AForce As Boolean) As Integer Implements IPluginAdapter.BOIncludeAttrIntoInstance

'    End Function

'    Public Function BOIncludeAttrIntoList1(BOHandle As Integer, AAttributeName As String, AInclude As Boolean, AForce As Boolean) As Integer Implements IPluginAdapter.BOIncludeAttrIntoList

'    End Function

'    Public Function BOInsert1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOInsert

'    End Function

'    Public Function BOIsAttributeInInstance1(BOHandle As Integer, AAttributeName As String) As Boolean Implements IPluginAdapter.BOIsAttributeInInstance

'    End Function

'    Public Function BOIsAttributeInList1(BOHandle As Integer, AAttributeName As String) As Boolean Implements IPluginAdapter.BOIsAttributeInList

'    End Function

'    Public Function BOIsEmpty1(BOHandle As Integer) As Boolean Implements IPluginAdapter.BOIsEmpty

'    End Function

'    Public Function BOIsEntity1(BOHandle As Integer, AEntityId As Integer) As Boolean Implements IPluginAdapter.BOIsEntity

'    End Function

'    Public Function BOIsEntityArray1(BOHandle As Integer, AEntityIds As Object) As Boolean Implements IPluginAdapter.BOIsEntityArray

'    End Function

'    Public Function BOLast1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOLast

'    End Function

'    Public Function BOLocateByAttributes1(BOHandle As Integer, AAttributeNames As Object, AAttributeValues As Object) As Integer Implements IPluginAdapter.BOLocateByAttributes

'    End Function

'    Public Function BOLocatePosition1(BOHandle As Integer, APosition As Object) As Boolean Implements IPluginAdapter.BOLocatePosition

'    End Function

'    Public Function BONext1(BOHandle As Integer) As Integer Implements IPluginAdapter.BONext

'    End Function

'    Public Function BOOpen1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOOpen

'    End Function

'    Public Function BOPost1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOPost

'    End Function

'    Public Function BOPostAllDataSets1(BOHandle As Integer, PostCollections As Boolean) As Integer Implements IPluginAdapter.BOPostAllDataSets

'    End Function

'    Public Function BOPostEx1(BOHandle As Integer, ACancelOnError As Boolean) As Integer Implements IPluginAdapter.BOPostEx

'    End Function

'    Public Function BOPrint1(BOHandle As Integer, ADocDesignName As String, AOverridePrinterName As String) As Integer Implements IPluginAdapter.BOPrint

'    End Function

'    Public Function BOPrior1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOPrior

'    End Function

'    Public Function BORecalculateAttribute1(BOHandle As Integer, AAttributeName As String) As Integer Implements IPluginAdapter.BORecalculateAttribute

'    End Function

'    Public Function BORefresh1(BOHandle As Integer) As Integer Implements IPluginAdapter.BORefresh

'    End Function

'    Public Function BORefreshRecord1(BOHandle As Integer, AForce As Boolean, ARefreshCollection As Boolean) As Integer Implements IPluginAdapter.BORefreshRecord

'    End Function

'    Public Function BORollBack1(BOHandle As Integer) As Integer Implements IPluginAdapter.BORollBack

'    End Function

'    Public Function BOSetActive1(BOHandle As Integer, B As Boolean) As Integer Implements IPluginAdapter.BOSetActive

'    End Function

'    Public Function BOSetAttributeValueByName1(BOHandle As Integer, AttrName As String, AValue As Object) As Integer Implements IPluginAdapter.BOSetAttributeValueByName

'    End Function

'    Public Function BOSetAttributeValues1(BOHandle As Integer, AAttributeNames As Object, AValue As Object) As Integer Implements IPluginAdapter.BOSetAttributeValues

'    End Function

'    Public Function BOSetCommitOnPost1(BOHandle As Integer, B As Boolean) As Integer Implements IPluginAdapter.BOSetCommitOnPost

'    End Function

'    Public Function BOSetFilter1(BOHandle As Integer, ADomain As Integer, AValue As Object, AOperation As Integer, AFilterData As Boolean, AFilterLookup As Boolean) As Integer Implements IPluginAdapter.BOSetFilter

'    End Function

'    Public Function BOSetFilterAttr1(BOHandle As Integer, AAttributeName As String, AValue As Object, AOperation As Integer, AFilterData As Boolean, AFilterLookup As Boolean) As Integer Implements IPluginAdapter.BOSetFilterAttr

'    End Function

'    Public Function BOSetReadOnly1(BOHandle As Integer, B As Boolean) As Integer Implements IPluginAdapter.BOSetReadOnly

'    End Function

'    Public Function BOSetTempClosingState1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOSetTempClosingState

'    End Function

'    Public Function BOSortByAttribute1(BOHandle As Integer, AAttributeName As String, ASortOrder As Integer, AReopen As Boolean) As Integer Implements IPluginAdapter.BOSortByAttribute

'    End Function

'    Public Function BOSortByDomain1(BOHandle As Integer, ADomain As Integer, ASortOrder As Integer, AReopen As Boolean) As Integer Implements IPluginAdapter.BOSortByDomain

'    End Function

'    Public Function BOUpdateActiveInstance1(BOHandle As Integer, AForce As Boolean) As Integer Implements IPluginAdapter.BOUpdateActiveInstance

'    End Function

'    Public Function BOUpdateDataSetRecords1(BOHandle As Integer, IncludeRefs As Boolean) As Integer Implements IPluginAdapter.BOUpdateDataSetRecords

'    End Function

'    Public Function BOUpdateInstanceCollections1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOUpdateInstanceCollections

'    End Function

'    Public Function BOUpdateInstanceDataSet1(BOHandle As Integer, AForceRefresh As Boolean, AForceDataSetCreation As Boolean) As Boolean Implements IPluginAdapter.BOUpdateInstanceDataSet

'    End Function

'    Public Function BOUpdateListCollections1(BOHandle As Integer) As Integer Implements IPluginAdapter.BOUpdateListCollections

'    End Function

'    Public Function BOUpdateListDataSet1(BOHandle As Integer, AForceRefresh As Boolean, AForceDataSetCreation As Boolean) As Boolean Implements IPluginAdapter.BOUpdateListDataSet

'    End Function

'    Public ReadOnly Property ChildBOList1 As Object Implements IPluginAdapter.ChildBOList
'        Get

'        End Get
'    End Property

'    Public Sub ClearLastError1() Implements IPluginAdapter.ClearLastError

'    End Sub

'    Public Function CloneBOHandle1(SrcBOHandle As Integer, SrcAdapter As IPluginAdapter) As Integer Implements IPluginAdapter.CloneBOHandle

'    End Function

'    Public Function Connect1(RoleName As String, Username As String, Password As String) As Boolean Implements IPluginAdapter.Connect

'    End Function

'    Public Function CreateBOByID1(BOID As Integer) As Integer Implements IPluginAdapter.CreateBOByID

'    End Function

'    Public Function CreateBOByName1(BOName As String) As Integer Implements IPluginAdapter.CreateBOByName

'    End Function

'    Public ReadOnly Property CurrentEmplId1 As String Implements IPluginAdapter.CurrentEmplId
'        Get

'        End Get
'    End Property

'    Public ReadOnly Property CurrentUserId1 As String Implements IPluginAdapter.CurrentUserId
'        Get

'        End Get
'    End Property

'    Public Function Disconnect1() As Integer Implements IPluginAdapter.Disconnect

'    End Function

'    Public Function DSCommit1() As Integer Implements IPluginAdapter.DSCommit

'    End Function

'    Public Function DSCreateDataset1(ADatasetName As String, AVendorSid As String, ACMSObject As String) As String Implements IPluginAdapter.DSCreateDataset

'    End Function

'    Public Function DSCreateVendor1(AVendorName As String) As String Implements IPluginAdapter.DSCreateVendor

'    End Function

'    Public Sub DSDeleteDatasetData1(ADatasetSid As String) Implements IPluginAdapter.DSDeleteDatasetData

'    End Sub

'    Public Sub DSDeleteIndex1(ADatasetSid As String, ARecSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String, ACMSRefKey1 As String, ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String) Implements IPluginAdapter.DSDeleteIndex

'    End Sub

'    Public Sub DSDeleteRecord1(ADataRecordSid As String) Implements IPluginAdapter.DSDeleteRecord

'    End Sub

'    Public Sub DSDropDataset1(ADatasetSid As String, ACascade As Boolean) Implements IPluginAdapter.DSDropDataset

'    End Sub

'    Public Sub DSDropVendor1(AVendorSid As String) Implements IPluginAdapter.DSDropVendor

'    End Sub

'    Public Function DSGetDatasetSid1(AVendorSid As String, ADatasetName As String) As String Implements IPluginAdapter.DSGetDatasetSid

'    End Function

'    Public Function DSGetRecordByCMSReference1(ADatasetSid As String, ACMSRefKey1 As String, ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String, ByRef ResultSet As Object) As Integer Implements IPluginAdapter.DSGetRecordByCMSReference

'    End Function

'    Public Function DSGetRecordByLookup1(ADatasetSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String, ByRef ResultSet As Object) As Integer Implements IPluginAdapter.DSGetRecordByLookup

'    End Function

'    Public Function DSGetRecordBySid1(ADataRecordSid As String, ByRef ResultSet As Object) As Integer Implements IPluginAdapter.DSGetRecordBySid

'    End Function

'    Public Function DSGetRecordSidByCMSReference1(ADatasetSid As String, ACMSRefKey1 As String, ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String) As String Implements IPluginAdapter.DSGetRecordSidByCMSReference

'    End Function

'    Public Function DSGetRecordSidByLookup1(ADatasetSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String) As String Implements IPluginAdapter.DSGetRecordSidByLookup

'    End Function

'    Public Function DSGetVendorSID1(AVendorName As String) As String Implements IPluginAdapter.DSGetVendorSID

'    End Function

'    Public Function DSInsertIndex1(ADatasetSid As String, ARecordSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String, ACMSRefKey1 As String, ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String) As String Implements IPluginAdapter.DSInsertIndex

'    End Function

'    Public Function DSInsertRecord1(ADatasetSid As String, ARecordValue As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String, ACMSRefKey1 As String, ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String) As String Implements IPluginAdapter.DSInsertRecord

'    End Function

'    Public Sub DSModifyDataset1(ADatasetSid As String, ANewDatasetName As String, ANewCMSObject As String) Implements IPluginAdapter.DSModifyDataset

'    End Sub

'    Public Sub DSModifyIndexLookup1(ADataRecordSid As String, ALookupKey1 As String, ALookupKey2 As String, ALookupKey3 As String) Implements IPluginAdapter.DSModifyIndexLookup

'    End Sub

'    Public Sub DSModifyIndexReference1(ADataRecordSid As String, ACMSRefKey1 As String, ACMSRefKey2 As Integer, ACMSRefKey3 As Integer, ACMSRefKey4 As Integer, ACMSRefKey5 As String) Implements IPluginAdapter.DSModifyIndexReference

'    End Sub

'    Public Sub DSModifyVendor1(AVendorSid As String, ANewName As String) Implements IPluginAdapter.DSModifyVendor

'    End Sub

'    Public Sub DSUpdateRecord1(ADataRecordSid As String, ANewValue As String) Implements IPluginAdapter.DSUpdateRecord

'    End Sub

'    Public Property Enabled1 As Boolean Implements IPluginAdapter.Enabled

'    Public Function EOF1(BOHandle As Integer) As Boolean Implements IPluginAdapter.EOF

'    End Function

'    Public Function ExecSQL1(SQL As String, ByRef ResultSet As Object) As Integer Implements IPluginAdapter.ExecSQL

'    End Function

'    Public Function GetBOEntityProperties1(ABOType As Integer) As String Implements IPluginAdapter.GetBOEntityProperties

'    End Function

'    Public Function GetBOTypeForEntityID1(AEntityId As Integer) As Integer Implements IPluginAdapter.GetBOTypeForEntityID

'    End Function

'    Public Function GetHandleForRootBO1(BOHandle As Integer) As Integer Implements IPluginAdapter.GetHandleForRootBO

'    End Function

'    Public Function GetReferenceBOForAttribute1(BOHandle As Integer, AAttributeName As String) As Integer Implements IPluginAdapter.GetReferenceBOForAttribute

'    End Function

'    Public Function GetSecurityPermission1(AApplicationID As Integer, APermissionID As Integer) As Boolean Implements IPluginAdapter.GetSecurityPermission

'    End Function

'    Public ReadOnly Property LanguageCodePage1 As Integer Implements IPluginAdapter.LanguageCodePage
'        Get

'        End Get
'    End Property

'    Public ReadOnly Property LanguageName1 As String Implements IPluginAdapter.LanguageName
'        Get

'        End Get
'    End Property

'    Public ReadOnly Property LastErrorCode1 As Integer Implements IPluginAdapter.LastErrorCode
'        Get

'        End Get
'    End Property

'    Public ReadOnly Property LastErrorFunction1 As String Implements IPluginAdapter.LastErrorFunction
'        Get

'        End Get
'    End Property

'    Public ReadOnly Property LastErrorMessage1 As String Implements IPluginAdapter.LastErrorMessage
'        Get

'        End Get
'    End Property

'    Public Sub LogEvent1(ALogEventType As Integer, AAreaName As String, AVerbosity As Integer, AMessage As String) Implements IPluginAdapter.LogEvent

'    End Sub

'    Public Function Rediscover1(AFlags As Integer) As Integer Implements IPluginAdapter.Rediscover

'    End Function

'    Public ReadOnly Property Reference1 As Integer Implements IPluginAdapter.Reference
'        Get

'        End Get
'    End Property

'    Public Function SbsGetPref1(ASbs As Integer, APref As Integer) As Object Implements IPluginAdapter.SbsGetPref

'    End Function

'    Public Function UpdatePreferences1(Preference As IXMLDOMElement) As Integer Implements IPluginAdapter.UpdatePreferences

'    End Function

'End Class  'TCustomPluginAdapter
