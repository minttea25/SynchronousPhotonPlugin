# SynchronousPhotonPlugin

See: https://github.com/Kev9171/Synchronous

<br><br>
<h2> <로컬 서버 설정 방법></h2>

deploy\LoadBalancing\Master\bin\Master.xml.config - WebRPC > BaseUrl : host 변경
deploy\LoadBalancing\GameServer\bin\GameServer.xml.config - GameServer : ip및 포트 변경

<h2><플러그인 적용 방법></h2>

deploy\Plugins 에 SynchronousPlugin 디렉터리 생성<br>
deploy\Plugins\SynchronousPlugin 에 bin 디렉터리 생성<br>

아래 파일들을 deploy\Plugins\SynchronousPlugin\bin에 복사<br>
PhotonHivePlugin.dll<br>
PhotonHivePlugin.pdb<br>
SynchronousPlugin.dll<br> 
SynchronousPlugin.pdb<br> 
(위 항목들은 프로젝트 빌드 시에 생성되는 파일들)
<br><br>
deploy\LoadBalancing\GameServer\bin\plugin.config 파일 열고<br>
Name="SynchronousPlugin"<br>
AssemblyName="SynchronousPlugin.dll"<br>
Type="SynchronousPlugin.KWY.SynchronousPluginFactory"<br>
위 3개 항목 수정 후 저장<br>
