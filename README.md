# 스파르타 메타버스 만들기
## 프로젝트 설명
유니티를 활용해 자유롭게 돌아다닐 수 있고 미니게임이 여러개 있는 앱을 제작
## 프레임 워크 구상
* [아이디어 스케치와 메모(figma)](https://www.figma.com/design/sdNSlmYnrTuJmzQBm5uW8c/%EC%A0%9C%EB%AA%A9-%EC%97%86%EC%9D%8C?node-id=0-1&p=f&t=PAP5glTawhADmwMq-0)
  
  ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/FrameWork.jpg?raw=true)  
  + 완성된 게임의 모습을 먼저 정하기 위해 대략적인 화면 구성과 게임에 대한 아이디어 등을 작성하고 작업에 시작했습니다.
  + 만들어 놓은 미니게임 두개가 모바일용이었기 때문에 나머지 메인화면과 미니게임도 모바일용으로 맞춰서 설계했습니다.
* UI배치
  
  ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/FreeAspect.jpg?raw=true)
  
  + 모든 씬은 화면비가 바뀌어도 크게 이상해지지 않도록 UI가 배치되었습니다.
  + 이렇게 해두면 나중에 다른 플랫폼에 이식할 일이 생길 때 편하지 않을까 생각했습니다.  
## 메인화면 설명
* 들어가면 기본적으로 보이는 씬에 관한 설명입니다.  
  + 아이디어 스케치
      
    ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/MainMenuIdeaSketch.jpg?raw=true)  
  + 메인화면 배치
  
    ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/MainMenuFullShot.jpg?raw=true)
  + 인게임 스크린샷

    ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/MainMenu.jpg?raw=true)  
    - 플레이어의 스프라이트 모양과 어울리도록 횡스크롤의 형태로 화면을 만들었습니다.
    - 모바일 환경과 맞도록 클릭으로 맵을 돌아다닐 수 있게 만들었습니다.
    - 서핑을 하거나 박쥐를 잡을때 경험치가 쌓이고 메인화면에서 레벨업하게 하여 미니게임을 지속할 수 있는 이유를 부여하고자 했습니다. 
  
  + 맵 곳곳에 있는 오브젝트에 가까이 가면 미니게임에 입장할 수 있는 UI가 뜹니다.  
  
    ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/Main.jpg?raw=true)  

  + 미니게임 입장에는 스테미나를 소모하며 스테미나가 부족하면 경고창이 뜨며 입장이 되지 않습니다.  
  
    ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/NoStemina.jpg?raw=true)

  + 스테미나는 포장마차에서 음식을 사거나 구운 통닭을 먹어서 보충 할 수 있게 구성 할 생각이었지만 시간관계로 아직 추가하지 못했습니다.
    
    ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/Store.jpg)
    - 또한 레벨업시 스테미나가 가득 차기도 합니다.
### Debug 버튼 설명
  ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/DebugButton.jpg?raw=true)
  + MainMenu 씬에 저장된 데이터를 전부 지울 수 있는 버튼을 추가해뒀습니다.
  + 기본적으로는 비활성화 되어있기 때문에 활성화 한 다음 쓰시면 됩니다.
  
## 미니게임 설명
메타버스 내에서 재생할 수 있는 미니게임과 관련된 설명입니다.  

  ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/FreeAspect2.jpg?raw=true)  

  + 부자가 되자! 씬만 가로 화면비가 일정 이상 길어지면 검은색이 나오기 때문에 스크립팅으로 앵커를 조정해놨습니다.  
  때문에 에디터에서는 UI가 튀어나가도 게임을 재생하시면 화면비에 맞게 UI가 재조정됩니다. 
### 부자가 되자!  
  
* 기본 강의인 빗물받는 르탄이를 변형한 게임입니다.
    
  ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/RtanRain.jpg?raw=true)  
  + 모아야 하는 이유를 주기 위해 빗물에서 코인으로 변경하였습니다.  
  + 코인이 쏟아지듯이 연출되는것이 마음에 들어 코인생성 타이밍은 일부러 변경하지 않았습니다.  
  + 그냥 코인을 모으기만 하면 재미가 없다고 생각해 맞으면 게임이 끝나는 뼈가 랜덤하게 떨어지도록 처리했습니다.
### 통닭을 지켜라!  
  
* 기본 강의인 풍선을 지켜라를 변형한 게임입니다.  
  
  ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/MyShield.jpg?raw=true)  
  + 막대기를 박쥐, 구를 통닭으로 만들어 구를 지켜야 하는 이유를 시각적으로 전달하고자 했습니다.
  + 약 10초가 지날때마다 통닭을 다 굽는다는 느낌으로 10초마다 통닭 갯수가 늘어나게 하였습니다.
  + 통닭의 개수를 인벤토리 형태의 UI안에 표시하여 통닭이 얼마나 굽혔는지 바로 볼 수 있게 했습니다.
### 서핑을 하자!  
* 플래피 버드를 변형한 게임입니다.  
  
  + 아이디어 스케치
  
  ![예시 아이디어 스케치](https://github.com/parkha6/UnityProject/blob/main/Capture/RtanSurfSketch.jpg?raw=true)
    
  + 인게임 스크린샷
  
   ![예시 스크린샷](https://github.com/parkha6/UnityProject/blob/main/Capture/RtanSurf.jpg?raw=true)
  
  + 마우스를 누른 시간만큼 높게 점프를 합니다.  
  + 바닥에 닿아도 죽지 않기 때문에 난이도 조절을 위해 다단점프는 없에고 점프는 한번만 할 수 있게 바꿨습니다.  
  + 플레이어가 아슬아슬하게 뛰도록 유도하게 바위 위에 코인을 배치하였습니다.  
***
## 에셋 저작권
* 르탄이 이미지 : 스파르타 코딩클럽
* 폰트 : 배민 한나
* 배경에셋 : [Ocean and Clouds Free Pixel Art Backgrounds](https://craftpix.net/freebies/ocean-and-clouds-free-pixel-art-backgrounds/)
* UI 인터페이스 : [Free GUI for Cyberpunk Pixel Art](https://craftpix.net/freebies/free-gui-for-cyberpunk-pixel-art/)
* 코인에셋 : [Animated pixel coins by TotusLotus](https://totuslotus.itch.io/pixel-coins)
* 엄청 큰 해골이랑 뼈 에셋 : [Free Undead Tileset Top Down Pixel Art](https://craftpix.net/freebies/free-undead-tileset-top-down-pixel-art/?num=1&count=52&sq=undead&pos=3)
* 모닥불 에셋 : [Pixel Campfire FX – 7 Frame Loop by Silas](https://srobinson111.itch.io/pixel-campfire)
* 음식에셋 : [Free Pixel foods by ghostpixxells](https://ghostpixxells.itch.io/pixelfood)
* 박쥐에셋 : [Bat Pixel art (FREE) by QuimeraGames](https://quimeragames.itch.io/bat-pixel-art-free)
* 바위에셋 : [Rock Sprites by Xenophero](https://xenophero.itch.io/rock-sprites)
* 가을배경 에셋 : [Free Autumn Pixel Backgrounds for Game](https://craftpix.net/freebies/free-autumn-pixel-backgrounds-for-game/)
* 상점카트 에셋 : [Medieval Fantasy Shop by Soul_Sire](https://soulcode.itch.io/shop-asset-rpg)
* 레벨,스테미나바 UI : [RPG UI pack (demo) by Franuka ](https://franuka.itch.io/rpg-ui-pack-demo)
* 가방아이콘 : [Pocket Inventory Series #2 : Pixel Map](https://humblepixel.itch.io/pocket-inventory-series-2-pixel-map)
* 말풍선 에셋: [Pixel Speech balloon by JustAJoke](https://justajoke.itch.io/pixel-speech-balloon)
### 그 외 자체 제작 에셋
* 치킨을 꽃아놓은 막대기
