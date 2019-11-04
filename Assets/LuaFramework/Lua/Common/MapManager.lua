--进入地图初始化
local MapManager = {}
local jump = {}
function MapManager:Init(sceneName)
	print("MapManager Init sceneName " .. tostring(sceneName))
	local object = GameObject.Find("jump_ele")
	local or_x = object.transform.localPosition.x
	local or_y = object.transform.localPosition.y
	local or_z = object.transform.localPosition.z
	print("[MapManager] object " .. tostring(object))
	print("[MapManager] object.position " .. tostring(object.transform.localPosition))
	for i = 0,10 do
		local rand1 = math.random(1,5)
		local rand2 = math.random(2,8)
		local rand3 = math.random(3,10)
		local object = GameObject.New("jump_ele")
		object.transform.localPosition.x = or_x + rand1
		object.transform.localPosition.y = or_y + rand2
		object.transform.localPosition.z = or_z + rand3
		table.insert(jump,object)
		print("[MapManager] object " .. tostring(object))
	end
end
return MapManager
