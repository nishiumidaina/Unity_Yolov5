import subprocess
import mysql.connector

conn = mysql.connector.connect(
    host='127.0.0.1',
    port='3306',
    user='0000',
    password='0000',
    database='unityproject'
)
# 接続状況確認
print(conn.is_connected())
cur = conn.cursor(buffered=True)
cur.execute("SELECT * FROM spots")
db_lis = cur.fetchall()
print(db_lis)
# DB操作終了
cur.close()
for i in range(len(db_lis)):
    URL = db_lis[i][4]
    spot_id = db_lis[i][0]
    subprocess.Popen('python C:/Users/nishi/Desktop/GameProject/Person_Simulator/Unity_YOLOv5/yolov5/main.py --source "%s" --spot_id %s'% (URL,int(spot_id)),shell=True)

#playerSelect=str(sys.argv[1])
#print( "REPLY[" + playerSelect + "]:" + "YOLOv5,CS." )