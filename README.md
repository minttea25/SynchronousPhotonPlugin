# SynchronousPhotonPlugin

See: https://github.com/Kev9171/Synchronous

<로컬 서버 설정 방법>

deploy\LoadBalancing\Master\bin\Master.xml.config - WebRPC > BaseUrl : host 변경
deploy\LoadBalancing\GameServer\bin\GameServer.xml.config - GameServer : ip및 포트 변경

<플러그인 적용 방법>
deploy\Plugins 에 SynchronousPlugin 디렉터리 생성
deploy\Plugins\SynchronousPlugin 에 bin 디렉터리 생성
아래 파일들을 deploy\Plugins\SynchronousPlugin에 복사
PhotonHivePlugin.dll
PhotonHivePlugin.pdb
SynchronousPlugin.dll
SynchronousPlugin.pdb
(위 항목들은 프로젝트 빌드 시에 생성되는 파일들)

deploy\LoadBalancing\GameServer\bin\plugin.config 파일 열고
Name="SynchronousPlugin"
AssemblyName="SynchronousPlugin.dll"
Type="SynchronousPlugin.KWY.SynchronousPluginFactory"
위 3개 항목 수정 후 저장
