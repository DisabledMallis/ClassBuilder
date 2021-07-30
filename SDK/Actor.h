#ifndef GUARD_Actor
#define GUARD_Actor
#include "Math.h"
struct Actor {
	/* Fields */
	char padding_320[320];
	Vector2<float> LookingVec;
	char padding_480[152];
	bool OnGround;
	char padding_872[391];
	class BlockSource* WorldSource;
	/* Virtuals */
	void virt_pad_0() {};
	void virt_pad_1() {};
	void virt_pad_2() {};
	void virt_pad_3() {};
	void virt_pad_4() {};
	void virt_pad_5() {};
	void virt_pad_6() {};
	void virt_pad_7() {};
	void virt_pad_8() {};
	void virt_pad_9() {};
	void virt_pad_10() {};
	void virt_pad_11() {};
	void virt_pad_12() {};
	void virt_pad_13() {};
	void virt_pad_14() {};
	auto getPos() -> Vector3<float>* {};
	/* Functions */
	static inline uintptr_t holder_setRot;
	auto __thiscall setRot(Vector2<float>* rotation) -> void {
		if(holder_setRot == 0) {
			holder_setRot = Mem::FindSig("89 ?? ?? ?? 57 48 83 ?? ?? 8B ?? ?? 48 8B ?? 48 81");
		}
		if(holder_setRot == 0){
			Utils::DebugF("FATAL: Sig failure for setRot");
		}
		holder_setRot += -1;
		((void(__thiscall*)(Actor*, Vector2<float>* rotation))holder_setRot)(this, rotation);
	};
};
#endif