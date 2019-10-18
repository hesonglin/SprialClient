Controller = {}
local this = Controller

local GameObject = UnityEngine.GameObject
local Input = UnityEngine.Input
local Rigidbody = UnityEngine.Rigidbody
local AudioSource = UnityEngine.AudioSource
local Color = UnityEngine.Color

local sphere
local rigi
local force

function this.start()
	sphere = GameObject.Find("Sphere")
	sphere : GetComponent("Renderer").material.color = Color(1,0.1,1)
	sphere : AddComponent(typeof(Rigidbody))
	
	rigi = sphere : GetComponent("Rigidbody")
	force = 5
end

function this.update()
	local h = Input.GetAxis("Horizontal")
	local v = Input.GetAxis("Vertical")
	
	rigi : AddForce(Vector3(h,0,v) * force)
end
