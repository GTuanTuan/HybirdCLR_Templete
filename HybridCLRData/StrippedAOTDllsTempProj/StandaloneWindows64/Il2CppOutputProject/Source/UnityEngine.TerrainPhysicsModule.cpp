#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>



struct Collider_t1CC3163924FCD6C4CC2E816373A929C1E3D55E76;
struct String_t;
struct TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05;
struct TerrainData_t615A68EAC648066681875D47FC641496D12F2E24;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;



IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_tFDA9EF4E2C0DEDF01BC846194862090332E1829C 
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	float ___m_value;
};
struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 
{
	float ___x;
	float ___y;
};
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 
{
	float ___x;
	float ___y;
	float ___z;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	intptr_t ___m_CachedPtr;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr;
};
struct Ray_t2B1742D7958DC05BDC3EFC7461D3593E1430DC00 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Origin;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Direction;
};
struct RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Point;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Normal;
	uint32_t ___m_FaceID;
	float ___m_Distance;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_UV;
	int32_t ___m_Collider;
};
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};
struct TerrainData_t615A68EAC648066681875D47FC641496D12F2E24  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};
struct Collider_t1CC3163924FCD6C4CC2E816373A929C1E3D55E76  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};
struct TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05  : public Collider_t1CC3163924FCD6C4CC2E816373A929C1E3D55E76
{
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct TerrainData_t615A68EAC648066681875D47FC641496D12F2E24_StaticFields
{
	int32_t ___k_MaximumResolution;
	int32_t ___k_MinimumDetailResolutionPerPatch;
	int32_t ___k_MaximumDetailResolutionPerPatch;
	int32_t ___k_MaximumDetailPatchCount;
	int32_t ___k_MinimumAlphamapResolution;
	int32_t ___k_MaximumAlphamapResolution;
	int32_t ___k_MinimumBaseMapResolution;
	int32_t ___k_MaximumBaseMapResolution;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainCollider_Raycast_Injected_m6F13C3753C7BC5C63F097B1B0F77089E63F1A9EE (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05* __this, Ray_t2B1742D7958DC05BDC3EFC7461D3593E1430DC00* ___0_ray, float ___1_maxDistance, bool ___2_hitHoles, bool* ___3_hasHit, RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5* ___4_ret, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5 TerrainCollider_Raycast_m35FB606FA5A477BFA22A3B30B9822ABA7CFF4A60 (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05* __this, Ray_t2B1742D7958DC05BDC3EFC7461D3593E1430DC00 ___0_ray, float ___1_maxDistance, bool ___2_hitHoles, bool* ___3_hasHit, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Collider__ctor_m8975C6CCFC0E5740C523DB4A52ACC7F4A021F8FA (Collider_t1CC3163924FCD6C4CC2E816373A929C1E3D55E76* __this, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* TerrainCollider_get_terrainData_m4B39540CB704719FA710B1D3837D9D1CD39AC07A (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05* __this, const RuntimeMethod* method) 
{
	typedef TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* (*TerrainCollider_get_terrainData_m4B39540CB704719FA710B1D3837D9D1CD39AC07A_ftn) (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05*);
	static TerrainCollider_get_terrainData_m4B39540CB704719FA710B1D3837D9D1CD39AC07A_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainCollider_get_terrainData_m4B39540CB704719FA710B1D3837D9D1CD39AC07A_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainCollider::get_terrainData()");
	TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* icallRetVal = _il2cpp_icall_func(__this);
	return icallRetVal;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainCollider_set_terrainData_mF77FBF6CCEFBBE591D729E02E0873B58C2F2E0BE (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05* __this, TerrainData_t615A68EAC648066681875D47FC641496D12F2E24* ___0_value, const RuntimeMethod* method) 
{
	typedef void (*TerrainCollider_set_terrainData_mF77FBF6CCEFBBE591D729E02E0873B58C2F2E0BE_ftn) (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05*, TerrainData_t615A68EAC648066681875D47FC641496D12F2E24*);
	static TerrainCollider_set_terrainData_mF77FBF6CCEFBBE591D729E02E0873B58C2F2E0BE_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainCollider_set_terrainData_mF77FBF6CCEFBBE591D729E02E0873B58C2F2E0BE_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainCollider::set_terrainData(UnityEngine.TerrainData)");
	_il2cpp_icall_func(__this, ___0_value);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5 TerrainCollider_Raycast_m35FB606FA5A477BFA22A3B30B9822ABA7CFF4A60 (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05* __this, Ray_t2B1742D7958DC05BDC3EFC7461D3593E1430DC00 ___0_ray, float ___1_maxDistance, bool ___2_hitHoles, bool* ___3_hasHit, const RuntimeMethod* method) 
{
	RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		float L_0 = ___1_maxDistance;
		bool L_1 = ___2_hitHoles;
		bool* L_2 = ___3_hasHit;
		TerrainCollider_Raycast_Injected_m6F13C3753C7BC5C63F097B1B0F77089E63F1A9EE(__this, (&___0_ray), L_0, L_1, L_2, (&V_0), NULL);
		RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5 L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TerrainCollider_Raycast_m1B165C5E60C20F895704BB4032CA0A36E3DAED2F (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05* __this, Ray_t2B1742D7958DC05BDC3EFC7461D3593E1430DC00 ___0_ray, RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5* ___1_hitInfo, float ___2_maxDistance, bool ___3_hitHoles, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	{
		V_0 = (bool)0;
		RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5* L_0 = ___1_hitInfo;
		Ray_t2B1742D7958DC05BDC3EFC7461D3593E1430DC00 L_1 = ___0_ray;
		float L_2 = ___2_maxDistance;
		bool L_3 = ___3_hitHoles;
		RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5 L_4;
		L_4 = TerrainCollider_Raycast_m35FB606FA5A477BFA22A3B30B9822ABA7CFF4A60(__this, L_1, L_2, L_3, (&V_0), NULL);
		*(RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5*)L_0 = L_4;
		bool L_5 = V_0;
		V_1 = L_5;
		goto IL_0019;
	}

IL_0019:
	{
		bool L_6 = V_1;
		return L_6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainCollider__ctor_mC7DD5783B65E6AB3F2CC52CEAD67ADCE9A95CBFE (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05* __this, const RuntimeMethod* method) 
{
	{
		Collider__ctor_m8975C6CCFC0E5740C523DB4A52ACC7F4A021F8FA(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TerrainCollider_Raycast_Injected_m6F13C3753C7BC5C63F097B1B0F77089E63F1A9EE (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05* __this, Ray_t2B1742D7958DC05BDC3EFC7461D3593E1430DC00* ___0_ray, float ___1_maxDistance, bool ___2_hitHoles, bool* ___3_hasHit, RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5* ___4_ret, const RuntimeMethod* method) 
{
	typedef void (*TerrainCollider_Raycast_Injected_m6F13C3753C7BC5C63F097B1B0F77089E63F1A9EE_ftn) (TerrainCollider_tBCAC2FC868B0E00ACB88A0E8FEDDE44DABE6DA05*, Ray_t2B1742D7958DC05BDC3EFC7461D3593E1430DC00*, float, bool, bool*, RaycastHit_t6F30BD0B38B56401CA833A1B87BD74F2ACD2F2B5*);
	static TerrainCollider_Raycast_Injected_m6F13C3753C7BC5C63F097B1B0F77089E63F1A9EE_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (TerrainCollider_Raycast_Injected_m6F13C3753C7BC5C63F097B1B0F77089E63F1A9EE_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.TerrainCollider::Raycast_Injected(UnityEngine.Ray&,System.Single,System.Boolean,System.Boolean&,UnityEngine.RaycastHit&)");
	_il2cpp_icall_func(__this, ___0_ray, ___1_maxDistance, ___2_hitHoles, ___3_hasHit, ___4_ret);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
