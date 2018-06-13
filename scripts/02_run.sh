chmod +x ../src/Snake.Gameloop/run.sh
chmod +x ../src/Snake.Input/run.sh
chmod +x ../src/Snake.Leaderboard/run.sh
chmod +x ../src/Snake.Map/run.sh

../src/Snake.Gameloop/run.sh & ../src/Snake.Input/run.sh & ../src/Snake.Leaderboard/run.sh & ../src/Snake.Map/run.sh &
npm start --prefix ../src/Snake &
npm start --prefix ../src/Snake.Input/Snake.Input.Web &
npm start --prefix ../src/Snake.Leaderboard/Snake.Leaderboard.Web &
npm start --prefix ../src/Snake.Map/Snake.Map.Web &